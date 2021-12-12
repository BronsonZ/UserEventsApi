using System.Collections.Generic;
using UserEventsApi.Models;

namespace UserEventsApi.Data
{
    public interface IUserEventRepo
    {
        IEnumerable<UserEvent> GetEvents();

        UserEvent AddEvent(UserEvent userEvent);

    }
}
