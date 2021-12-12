using System;
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
        public void AddEvent(UserEvent userEvent)
        {
            if( userEvent == null)
            {
                throw new ArgumentNullException(nameof(userEvent));
            }

            context.UserEvents.Add(userEvent);

        }

        public IEnumerable<UserEvent> GetEvents()
        {
            return context.UserEvents.ToList();
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
