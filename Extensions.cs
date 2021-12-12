using UserEventsApi.Dtos;
using UserEventsApi.Models;

namespace UserEventsApi
{
    public static class Extensions
    {
        public static UserEventDto AsDto(this UserEvent userEvent)
        {
            return new UserEventDto
            {
                Username = userEvent.Username,
                TimeStamp = userEvent.TimeStamp,
                ActionTaken = userEvent.ActionTaken,
                Data = userEvent.Data
            };
        }
    }
}

