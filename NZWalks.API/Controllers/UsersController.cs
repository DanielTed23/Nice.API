using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DAL.Repositories;
using DAL.Models.DTO;
using DAL.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserRequestDto addUserRequestDto)
        {
            // Tjek om e-mail allerede findes
            var existingUser = await userRepository.GetByEmailAsync(addUserRequestDto.Email);
            if (existingUser != null)
            {
                return BadRequest(new { Message = "Denne e-mail er allerede registreret." });
            }

            // Map DTO til Domain Model
            var userDomainModel = mapper.Map<User>(addUserRequestDto);

            // Opret bruger
            await userRepository.CreateAsync(userDomainModel);

            // Returner succes
            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usersDomainModel = await userRepository.GetAllAsync();
            return Ok(mapper.Map<List<UserDto>>(usersDomainModel));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDomainModel = await userRepository.GetByIdAsync(id);

            if (userDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            var userDomainModel = mapper.Map<User>(updateUserRequestDto);

            userDomainModel = await userRepository.UpdateAsync(id, userDomainModel);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(userDomainModel));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedUserDomainModel = await userRepository.DeleteAsync(id);
            if (deletedUserDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(deletedUserDomainModel));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var userDomainModel = await userRepository.GetByEmailAsync(loginRequestDto.Email);

            if (userDomainModel == null || userDomainModel.Password != loginRequestDto.Password)
            {
                return Unauthorized(new { Message = "Ugyldig e-mail eller adgangskode." });
            }

            bool isAdmin = userDomainModel.Email.ToLower() == "admin@example.com";

            return Ok(new LoginResponseDto
            {
                Token = "dummy-token",
                IsAdmin = isAdmin
            });
        }
    }
}
