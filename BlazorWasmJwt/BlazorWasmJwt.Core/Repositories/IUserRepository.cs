using System.Threading.Tasks;
using BlazorWasmJwt.Core.Dtos;
using BlazorWasmJwt.Core.Models;

namespace BlazorWasmJwt.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task<User> CreateAsync(UserCreateDto model);
    }
}