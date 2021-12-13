using System.Collections.Generic;
using UserEventsApi.Models;

namespace UserEventsApi.Data
{
    public interface IUserEventsRepo
    {
        bool SaveChanges();

        IEnumerable<UserEvent> GetEvents();

        UserEvent GetEventById(int id);

        void AddEvent(UserEvent userEvent);

        UserEventData GetUserEventData();

    }
}
