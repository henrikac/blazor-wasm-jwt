using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlazorWasmJwt.Core.Dtos;
using BlazorWasmJwt.Core.Models;
using BlazorWasmJwt.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BlazorWasmJwt.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AuthController(IOptions<AppSettings> appSettings, IMapper mapper, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(UserLoginDto model)
        {
            User user = await _userRepository.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return BadRequest("Invalid credentials");
            }

            bool verified = BCrypt.Net.BCrypt.Verify(model.Password, user.HashedPassword);

            if (!verified)
            {
                return BadRequest("Invalid credentials");
            }

            return Ok(new { token = generateJwtToken(user) });
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}