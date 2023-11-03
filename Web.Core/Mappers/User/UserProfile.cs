using AutoMapper;
using Ecom.Core.DTOs.Account;
using WebApp.BFF.Core.Models;

namespace Web.Core.Mappers.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();
        }
    }
}
