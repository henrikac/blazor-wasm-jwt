using System.Threading.Tasks;
using BlazorWasmJwt.Core.Dtos;
using BlazorWasmJwt.Core.Models;

namespace BlazorWasmJwt.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(UserCreateDto model);
    }
}