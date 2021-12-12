using System.Collections.Generic;
using System.Linq;
using UserEventsApi.Models;

namespace UserEventsApi.Data
{
    public class SqlUserEventsRepo : IUserEventsRepo
    {
        private readonly UserEventsApiDbContext context;

        public SqlUserEventsRepo(UserEventsApiDbContext context)
        {
            this.context = context;
        }
        public UserEvent AddEvent(UserEvent userEvent)
        {
            context.UserEvents.Append(userEvent);
            return userEvent;
        }

        public IEnumerable<UserEvent> GetEvents()
        {
            return context.UserEvents.ToList();
        }
    }
}
