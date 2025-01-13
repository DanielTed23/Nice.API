using AutoMapper;
using DAL.Models.Domain;
using DAL.Models.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly ICinemaHallRepository _cinemaHallRepository;

        public MoviesController(IMapper mapper, IMovieRepository movieRepository, ICinemaHallRepository cinemaHallRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _cinemaHallRepository = cinemaHallRepository;
        }

        // CREATE Movie with Poster Upload and CinemaHallId
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddMovieRequestDto addMovieRequestDto, [FromForm] IFormFile? poster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Validation errors occurred.", errors = ModelState });
            }

            string? posterPath = null;

            try
            {
                // Validate CinemaHallId
                var cinemaHall = await _cinemaHallRepository.GetByIdAsync(addMovieRequestDto.CinemaHallId);
                if (cinemaHall == null)
                {
                    return BadRequest(new { message = "Invalid CinemaHallId provided." });
                }

                // Save poster if uploaded
                if (poster != null)
                {
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    posterPath = Path.Combine(uploadFolder, poster.FileName);
                    using (var stream = new FileStream(posterPath, FileMode.Create))
                    {
                        await poster.CopyToAsync(stream);
                    }
                }

                // Map DTO to Domain Model
                var movieDomainModel = _mapper.Map<Movie>(addMovieRequestDto);
                movieDomainModel.PosterPath = posterPath;

                // Save movie to database
                await _movieRepository.CreateAsync(movieDomainModel);

                return Ok(_mapper.Map<MovieDto>(movieDomainModel));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        // GET Movies
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var moviesDomainModel = await _movieRepository.GetAllAsync();
                return Ok(_mapper.Map<List<MovieDto>>(moviesDomainModel));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        // Get Movie By Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var movieDomainModel = await _movieRepository.GetByIdAsync(id);

                if (movieDomainModel == null)
                {
                    return NotFound(new { message = "Movie not found." });
                }

                return Ok(_mapper.Map<MovieDto>(movieDomainModel));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        // UPDATE Movie By Id with Poster
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateMovieRequestDto updateMovieRequestDto, [FromForm] IFormFile? poster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var movieDomainModel = await _movieRepository.GetByIdAsync(id);

                if (movieDomainModel == null)
                {
                    return NotFound(new { message = "Movie not found." });
                }

                // Update poster if uploaded
                if (poster != null)
                {
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    var posterPath = Path.Combine(uploadFolder, poster.FileName);
                    using (var stream = new FileStream(posterPath, FileMode.Create))
                    {
                        await poster.CopyToAsync(stream);
                    }

                    movieDomainModel.PosterPath = posterPath;
                }

                // Update data from DTO
                _mapper.Map(updateMovieRequestDto, movieDomainModel);

                await _movieRepository.UpdateAsync(id, movieDomainModel);

                return Ok(_mapper.Map<MovieDto>(movieDomainModel));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        // DELETE Movie By Id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedMovieDomainModel = await _movieRepository.DeleteAsync(id);
                if (deletedMovieDomainModel == null)
                {
                    return NotFound(new { message = "Movie not found." });
                }

                return Ok(_mapper.Map<MovieDto>(deletedMovieDomainModel));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }
    }
}
