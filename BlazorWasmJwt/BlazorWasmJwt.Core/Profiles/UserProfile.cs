using AutoMapper;
using BlazorWasmJwt.Core.Dtos;
using BlazorWasmJwt.Core.Models;

namespace BlazorWasmJwt.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
        }
    }
}