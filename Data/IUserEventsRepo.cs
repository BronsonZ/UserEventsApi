using System.Collections.Generic;
using UserEventsApi.Models;

namespace UserEventsApi.Data
{
    public interface IUserEventsRepo
    {
        IEnumerable<UserEvent> GetEvents();

        UserEvent AddEvent(UserEvent userEvent);

    }
}
