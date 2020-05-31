using System;
using CheckCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckCenter.ApplicationInterface.ReadOnly
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/checks")]
    public class ReadOnlyEventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IFinishedEventRepository _finishedEventRepository;

        public ReadOnlyEventController(IEventRepository eventRepository, IFinishedEventRepository finishedEventRepository)
        {
            _eventRepository = eventRepository;
            _finishedEventRepository = finishedEventRepository;
        }

        [HttpGet]
        public ActionResult GetAllEvents([FromQuery] long since = 0, [FromQuery] bool active = true)
        {
            if (since <= 0)
                return Ok(
                    active ? _eventRepository.GetAllEvents() : _finishedEventRepository.GetAllFinishedEvents());

            var sinceTime = new DateTime(since); // Ticks
            return Ok(_eventRepository.GetAllUpdatedEventsSince(sinceTime));
        }

        [HttpGet("{id}")]
        public ActionResult GetEvent(int id, [FromQuery] bool active = true)
        {
            if (active)
            {
                var @event = _eventRepository.GetEvent(id);
                if (@event.Id > 0) return Ok(@event);
            }
            else
            {
                var @arEvent = _finishedEventRepository.GetFinishedEvent(id);
                if (@arEvent.Id > 0) return Ok(@arEvent);
            }

            return NotFound();
        }
    }
}
