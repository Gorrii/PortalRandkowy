
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalRandkowy.API.Data;
using PortalRandkowy.API.Dtos;
using PortalRandkowy.API.Models;

namespace PortalRandkowy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _repository.UserExists(userForRegisterDto.UserName))
                return BadRequest("User already exist");

            var userToCreate = new User{
                UserName = userForRegisterDto.UserName
            };

            var createdUser = await _repository.Register(userToCreate,userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}