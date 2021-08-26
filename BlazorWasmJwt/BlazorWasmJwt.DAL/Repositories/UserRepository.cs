using System;
using System.Threading.Tasks;
using AutoMapper;
using BlazorWasmJwt.Core.Dtos;
using BlazorWasmJwt.Core.Models;
using BlazorWasmJwt.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmJwt.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlazorJwtContext _context;
        private readonly IMapper _mapper;

        public UserRepository(BlazorJwtContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(UserCreateDto model)
        {
            User emailExist = await _context.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == model.Email.ToUpper());

            if (emailExist is not null)
            {
                return null;
            }

            User usernameExist = await _context.Users.FirstOrDefaultAsync(u => u.NormalizedUsername == model.Username.ToUpper());

            if (usernameExist is not null)
            {
                return null;
            }

            User user = _mapper.Map<User>(model);

            user.NormalizedUsername = model.Username.ToUpper();
            user.NormalizedEmail = model.Email.ToUpper();
            user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            DateTime now = DateTime.UtcNow;
            user.CreatedAt = now;
            user.UpdatedAt = now;

            _context.Add(user);
            bool success = await _context.SaveChangesAsync() > 0;

            return success ? user : null;
        }
    }
}