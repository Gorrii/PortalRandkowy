
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortalRandkowy.API.Data;
using PortalRandkowy.API.Dtos;
using PortalRandkowy.API.Models;


namespace PortalRandkowy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repository, IConfiguration config)
        {
            _config = config;
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _repository.UserExists(userForRegisterDto.UserName))
                return BadRequest("User already exist");

            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName
            };

            var createdUser = await _repository.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var UserFromRepo = await _repository.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);
            if (UserFromRepo == null)
                return Unauthorized();

            // create Token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, UserFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, UserFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };
        

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok( new {token = tokenHandler.WriteToken(token)});
        }
    }
}