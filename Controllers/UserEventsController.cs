using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserEventsApi.Data;
using UserEventsApi.Models;
using UserEventsApi.Dtos;
using System.Linq;
using System;

namespace UserEventsApi.Controllers
{
    
    [ApiController]
    [Route("api/userevents")]
    public class UserEventsController : ControllerBase
    {
        private readonly IUserEventsRepo repo;

        public UserEventsController(IUserEventsRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<UserEventDto> GetEvents()
        {
            var events = repo.GetEvents().Select(userEvent => userEvent.AsDto());
            return events;
        }

        [HttpPost]
        public ActionResult<UserEventDto> AddEvent(CreateUserEventDto newEvent)
        {
            UserEvent newUserEvent = new()
            {
                Username = newEvent.Username,
                ActionTaken = newEvent.ActionTaken,
                Data = newEvent.Data,
                TimeStamp = DateTimeOffset.UtcNow
            };

            repo.AddEvent(newUserEvent);
            return newUserEvent.AsDto();
        }


        
    }
}
