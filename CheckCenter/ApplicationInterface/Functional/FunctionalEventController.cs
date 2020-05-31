using System;
using System.Linq;
using CheckCenter.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CheckCenter.ApplicationInterface.Functional {
    [ApiController]
    [Produces("application/json")]
    [Route("/api/checks")]
    public class FunctionalEventController : ControllerBase {
        private readonly IEventRepository _eventRepository;
        private readonly IAdditionalInfoRepository _additionalInfoRepository;
        
        private readonly IActionLogRepository _actionLogRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ICommentRepository _commentRepository;

        public class DeleteBody {
            public string Conclusion { get; set; } = "";
        }


        public FunctionalEventController(IEventRepository eventRepository, ICommentRepository commentRepository,
            IAdditionalInfoRepository additionalInfoRepository, IActionLogRepository actionLogRepository,
            IFeedbackRepository feedbackRepository) {
            _eventRepository = eventRepository;
            _additionalInfoRepository = additionalInfoRepository;
            _actionLogRepository = actionLogRepository;
            _feedbackRepository = feedbackRepository;
            _commentRepository = commentRepository;
        }

        [HttpPost]
        public ActionResult CreateEvent([FromBody] Event @event) {
            try { 
                @event.Added = DateTime.Now;
                @event.Updated = DateTime.Now;
                var id = _eventRepository.CreateEvent(@event);
                if (id > 0) return Ok(new { id });
                return new UnsupportedMediaTypeResult();
            } catch {
                return new BadRequestResult();
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEvent([FromBody] Event @event, int id, [FromQuery] string userEmail = null)
        {
            @event.Id = id;
            var result = _eventRepository.UpdateEvent(@event, userEmail);
            return Ok(new { result });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(int id, [FromBody] DeleteBody body, [FromQuery] bool finished = false) {
            var @event = _eventRepository.GetEvent(id);
            if (!ValidateType(@event)) return Ok(new InvalidOperationException());

            var validatedEvent = (Event) @event;
            
            foreach (var comment in validatedEvent.Comments) _commentRepository.ArchiveComment(comment, id);
            foreach (var feedback in validatedEvent.Feedback) _feedbackRepository.ArchiveFeedback(feedback, id);
//            foreach (var actionlog in validatedEvent.ActionLogs) _actionLogRepository.ArchiveActionLog(actionlog, id);
            foreach (var info in validatedEvent.AdditionalInfo) _additionalInfoRepository.ArchiveAdditionalInfo(info, id);
            
            var result = _eventRepository.DeleteEvent(validatedEvent, body.Conclusion, finished);

            return Ok(new { result });
        }

        [HttpPost("{id}/info")]
        public ActionResult CreateAdditionalInfo([FromBody] AdditionalInfo additionalInfo, int id) {
            try {
                var @event = _eventRepository.GetEvent(id);
                if (!ValidateType(@event)) return Ok(new InvalidOperationException());
                additionalInfo.Event = (Event) _eventRepository.GetEvent(id);
                _additionalInfoRepository.CreateAdditionalInfo(additionalInfo);
                return Ok(new { id });
            } catch {
                return new BadRequestResult();
            }
        }

        [HttpPut("{id}/info/{infoId}")]
        public ActionResult UpdateAdditionalInfo([FromBody] AdditionalInfo additionalInfo, int id, int infoId) {
            additionalInfo.Id = infoId;
            var result = _additionalInfoRepository.UpdateAdditionalInfo(additionalInfo);
            _eventRepository.SetLastUpdated(id);
            return Ok(new { result });
        }

        [HttpDelete("{id}/info/{infoId}")]
        public ActionResult DeleteAdditionalInfo(int id, int infoId) {
            var result = _additionalInfoRepository.DeleteAdditionalInfo(infoId);
            _eventRepository.SetLastUpdated(id);
            return Ok(new { result });
        }

        [HttpPost("{id}/comments")]
        public ActionResult CreateComment([FromBody] Comment comment, int id) {
            try {
                var @event = _eventRepository.GetEvent(id);
                if (!ValidateType(@event)) return Ok(new InvalidOperationException());
                comment.Event = (Event) _eventRepository.GetEvent(id);
                _commentRepository.CreateComment(comment);
                _eventRepository.SetLastUpdated(id);
                return Ok(new {comment.Id});
            } catch {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{id}/comments/{commentId}")]
        public ActionResult DeleteComment(int id, int commentId) {
            var result = _commentRepository.DeleteComment(commentId);
            _eventRepository.SetLastUpdated(id);
            return Ok(new { result });
        }

        [HttpPost("{id}/feedback")]
        public ActionResult CreateFeedback([FromBody] Feedback feedback, int id) {
            try {
                var @event = _eventRepository.GetEvent(id);
                if (!ValidateType(@event)) return Ok(new InvalidOperationException());
                feedback.Event = (Event) _eventRepository.GetEvent(id);
                _feedbackRepository.CreateFeedback(feedback);
                _eventRepository.SetLastUpdated(id);
                return Ok(new {id});
            } catch {
                return new BadRequestResult();
            }
            
        }

        [HttpDelete("{id}/feedback/{feedbackId}")]
        public ActionResult DeleteFeedback(int id, int feedbackId) {
           var result = _feedbackRepository.DeleteFeedback(feedbackId);
            _eventRepository.SetLastUpdated(id);
            return Ok(new { result });
        }

        [HttpPost("{id}/actionlogs")]
        public ActionResult CreateActionLog([FromBody] ActionLog actionLog, int id) {
            try {
                var @event = _eventRepository.GetEvent(id);
                if (!ValidateType(@event)) return Ok(new InvalidOperationException());
                actionLog.Event = (Event) _eventRepository.GetEvent(id);
                _actionLogRepository.CreateActionLog(actionLog);
                _eventRepository.SetLastUpdated(id);
                return Ok(new {actionLog.Id});
            } catch {
                return new BadRequestResult();
            }
        }
        
        private bool ValidateType(IGenericEvent @event)
        {
            return (@event.GetType() == typeof(Event));
        }
    }
}
