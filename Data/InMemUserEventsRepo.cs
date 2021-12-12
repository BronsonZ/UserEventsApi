using System.Collections.Generic;
using UserEventsApi.Models;
using System;

namespace UserEventsApi.Data
{
    public class InMemUserEventsRepo : IUserEventsRepo
    {
        private readonly List<UserEvent> _events = new()
        {
            new UserEvent { Username = "Bronson", ActionTaken = "copy", Data = "lorem ipsum", TimeStamp = DateTimeOffset.UtcNow },
            new UserEvent { Username = "Cooper", ActionTaken = "print", Data = "http://example.com/printpage", TimeStamp = DateTimeOffset.UtcNow },
            new UserEvent { Username = "Bronson", ActionTaken = "link", Data = "http://example.com", TimeStamp = DateTimeOffset.UtcNow }
        };

        public UserEvent AddEvent(UserEvent userEvent)
        {
            _events.Add(userEvent);
            return userEvent;
        }

        public IEnumerable<UserEvent> GetEvents()
        {
            return _events;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        void IUserEventsRepo.AddEvent(UserEvent userEvent)
        {
            throw new NotImplementedException();
        }
    }
}
