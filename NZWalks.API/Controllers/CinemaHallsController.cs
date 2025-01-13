using AutoMapper;
using DAL.Models.Domain;
using DAL.Models.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaHallsController : ControllerBase
    {
        private readonly ICinemaHallRepository _cinemaHallRepository;
        private readonly IMapper _mapper;

        public CinemaHallsController(ICinemaHallRepository cinemaHallRepository, IMapper mapper)
        {
            _cinemaHallRepository = cinemaHallRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cinemaHalls = await _cinemaHallRepository.GetAllAsync();

                if (cinemaHalls == null || cinemaHalls.Count == 0)
                {
                    return NoContent(); // 204 hvis der ikke er nogen data
                }

                var cinemaHallDtos = _mapper.Map<List<CinemaHallDto>>(cinemaHalls);
                return Ok(cinemaHallDtos); // 200 med DTO'er
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving cinema halls.", details = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cinemaHall = await _cinemaHallRepository.GetByIdAsync(id);
                if (cinemaHall == null)
                {
                    return NotFound(new { message = "CinemaHall not found." });
                }

                var cinemaHallDto = _mapper.Map<CinemaHallDto>(cinemaHall);
                return Ok(cinemaHallDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the cinema hall.", details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCinemaHallDto addCinemaHallDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Validation errors occurred.", errors = ModelState });
            }

            try
            {
                var cinemaHall = _mapper.Map<CinemaHall>(addCinemaHallDto);
                var createdCinemaHall = await _cinemaHallRepository.CreateAsync(cinemaHall);

                var cinemaHallDto = _mapper.Map<CinemaHallDto>(createdCinemaHall);
                return CreatedAtAction(nameof(GetById), new { id = cinemaHallDto.CinemaHallId }, cinemaHallDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the cinema hall.", details = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AddCinemaHallDto addCinemaHallDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Validation errors occurred.", errors = ModelState });
            }

            try
            {
                var existingCinemaHall = await _cinemaHallRepository.GetByIdAsync(id);
                if (existingCinemaHall == null)
                {
                    return NotFound(new { message = "CinemaHall not found." });
                }

                _mapper.Map(addCinemaHallDto, existingCinemaHall);
                var updatedCinemaHall = await _cinemaHallRepository.UpdateAsync(id, existingCinemaHall);

                var cinemaHallDto = _mapper.Map<CinemaHallDto>(updatedCinemaHall);
                return Ok(cinemaHallDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the cinema hall.", details = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _cinemaHallRepository.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound(new { message = "CinemaHall not found." });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the cinema hall.", details = ex.Message });
            }
        }
    }
}
