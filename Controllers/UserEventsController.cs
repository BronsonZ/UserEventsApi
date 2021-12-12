using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserEventsApi.Data;
using UserEventsApi.Models;
using UserEventsApi.Dtos;
using System.Linq;
using System;
using AutoMapper;

namespace UserEventsApi.Controllers
{
    
    [ApiController]
    [Route("api/userevents")]
    public class UserEventsController : ControllerBase
    {
        private readonly IUserEventsRepo repo;
        private readonly IMapper mapper;

        public UserEventsController(IUserEventsRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserEventDto>> GetEvents()
        {
            //var events = repo.GetEvents().Select(userEvent => userEvent.AsDto());
            var events = repo.GetEvents();

            return Ok(mapper.Map<IEnumerable<UserEventDto>>(events));
            
        }

        [HttpPost]
        public ActionResult<CreateUserEventDto> AddEvent(CreateUserEventDto newEvent)
        {
            var userEventModel = mapper.Map<UserEvent>(newEvent);

            repo.AddEvent(userEventModel);

            repo.SaveChanges();

            return Ok(newEvent);
        }


        
    }
}
