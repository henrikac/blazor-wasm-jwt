using System.Threading.Tasks;
using AutoMapper;
using BlazorWasmJwt.Core.Dtos;
using BlazorWasmJwt.Core.Models;
using BlazorWasmJwt.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmJwt.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> Register(UserCreateDto model)
        {
            User user = await _userRepository.CreateAsync(model);

            if (user is null)
            {
                return BadRequest();
            }

            UserReadDto createdUser = _mapper.Map<UserReadDto>(user);

            return Ok(createdUser);
        }
    }
}