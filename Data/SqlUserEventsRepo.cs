using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UserEventsApi.Dtos;
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
            if(userEvent == null)
            {
                throw new ArgumentNullException(nameof(userEvent));
            }

            context.UserEvents.Add(userEvent);

        }

        public IEnumerable<UserEvent> GetEvents()
        {
            return context.UserEvents.ToList();
        }

        public UserEvent GetEventById(int id)
        {
            return context.UserEvents.FirstOrDefault(x => x.Id == id);
        }

        public UserEventData GetUserEventData()
        {

            var mostFreqEvent = context.UserEvents.AsEnumerable().GroupBy(x => x.ActionTaken).OrderByDescending(gp => gp.Count()).Take(1).ToList();

            string eventName = mostFreqEvent[0].Key;
            int numOfTimes = mostFreqEvent[0].Count();

            int numUniqueNames = context.UserEvents.Select(x => x.Username).Distinct().Count();

            double timesPerUser = (double) numOfTimes / numUniqueNames;

            UserEventData userEventData = new()
            {
                MostFreqEvent = eventName,
                NumberOfTimes = numOfTimes,
                NumberOfTimesPerUser = timesPerUser
            };

            return userEventData;
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
