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
        public ActionResult<UserEventDataDto> GetUserEventData()
        {
            var userEventsData = repo.GetUserEventData();
            return Ok(mapper.Map<UserEventDataDto>(userEventsData));
        }

        [HttpGet("{id}", Name="GetEventById")]
        public ActionResult<UserEventDto> GetEventById(int id)
        {
            var userEvent = repo.GetEventById(id);

            if(userEvent == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserEventDto>(userEvent));
        }

        [HttpPost]
        public ActionResult<CreateUserEventDto> AddEvent(CreateUserEventDto newEvent)
        {
            if(newEvent == null)
            {
                return BadRequest();
            }

            var userEvent = mapper.Map<UserEvent>(newEvent);

            userEvent.TimeStamp = DateTimeOffset.UtcNow;

            repo.AddEvent(userEvent);

            repo.SaveChanges();

            return CreatedAtRoute(nameof(GetEventById), new { userEvent.Id }, userEvent);
        }


        
    }
}
