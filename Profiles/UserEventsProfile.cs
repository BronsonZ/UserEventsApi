using AutoMapper;
using UserEventsApi.Dtos;
using UserEventsApi.Models;

namespace UserEventsApi.Profiles
{
    public class UserEventsProfile : Profile
    {
        public UserEventsProfile()
        {
            CreateMap<UserEvent, ReturnUserEventDto>();
            CreateMap<CreateUserEventDto, UserEvent>();
        }
    }
}
