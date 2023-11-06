using Web.App.Core.Web.Core.DTOs.Account;
using Web.App.Core.Web.Core.Models;
using AutoMapper;

namespace Web.App.Core.Web.Core.Mappers.User
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
