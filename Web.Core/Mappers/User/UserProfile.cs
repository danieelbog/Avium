using AutoMapper;
using Web.Core.DTOs.User;
using Web.Core.Models.User;

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
