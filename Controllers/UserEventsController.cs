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
        public ActionResult<IEnumerable<ReturnUserEventDto>> GetEvents()
        {
            var userEvents = repo.GetEvents();
            return Ok(mapper.Map<IEnumerable<ReturnUserEventDto>>(userEvents));
        }

        [HttpGet("{id}", Name="GetEventById")]
        public ActionResult<ReturnUserEventDto> GetEventById(int id)
        {
            var userEvent = repo.GetEventById(id);

            if(userEvent == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ReturnUserEventDto>(userEvent));
        }

        [HttpPost]
        public ActionResult<CreateUserEventDto> AddEvent(CreateUserEventDto newEvent)
        {
            if(newEvent == null)
            {
                return BadRequest();
            }

            var userEventModel = mapper.Map<UserEvent>(newEvent);

            userEventModel.TimeStamp = DateTimeOffset.UtcNow;

            repo.AddEvent(userEventModel);

            repo.SaveChanges();

            return CreatedAtRoute(nameof(GetEventById), new { userEventModel.Id }, userEventModel);
        }


        
    }
}
