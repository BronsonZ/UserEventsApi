using System.Collections.Generic;
using UserEventsApi.Models;

namespace UserEventsApi.Data
{
    public interface IUserEventsRepo
    {
        bool SaveChanges();
        IEnumerable<UserEvent> GetEvents();

        void AddEvent(UserEvent userEvent);

    }
}
