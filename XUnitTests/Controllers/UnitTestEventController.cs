using System;
using System.Collections.Generic;
using System.Text;
using CheckCenter.ApplicationInterface.Functional;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Sdk;
using static XUnitTests.Controllers.UnitTestController;

namespace XUnitTests.Controllers
{
    public class UnitTestEventController {

        [Fact]
        public void InvalidEventValuesShouldReturnBadRequest() {
            var controller = GetFunctionalEventController("event", "event");
            var result = controller.CreateEvent(Event.Mock(CheckType.Mock(), State.Mock(),
                Source.Mock(CheckType.Mock(), State.Mock())));
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void UpdateEventShouldReturnException() {
            var controller = GetFunctionalEventController("event", "event");
            var @event = Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock()));
            controller.CreateEvent(@event);

            Assert.ThrowsAny<Exception>(() => controller.UpdateEvent(@event, @event.Id));
        }

        [Fact]
        public void DeleteEventShouldReturnTrue() {
            var controller = GetFunctionalEventController("event", "event");
            var @event = Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock()));
            controller.CreateEvent(@event);

            var result = controller.DeleteEvent(@event.Id, new FunctionalEventController.DeleteBody());
            Assert.False(result == null, "Result should not be null");
        }

        [Fact]
        public void InvalidAdditionalInfoValuesShouldReturnBadRequest()
        {
            var controller = GetFunctionalEventController("info", "info");
            var result = controller.CreateAdditionalInfo(AdditionalInfo.Mock(), Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock())).Id);
            Assert.IsType<BadRequestResult>(result);
        }

        //[Fact]
        //public void UpdateAdditionalInfoShouldReturnException()
        //{
        //    var controller = GetFunctionalEventController("post1", "post1");
        //    var @event = Event.Mock(CheckType.Empty(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock()));
        //    controller.CreateEvent(@event);
        //    var info = AdditionalInfo.Mock();

        //    Assert.ThrowsAny<Exception>(() => controller.UpdateAdditionalInfo(info, @event.Id, info.Id));
        //}

        [Fact]
        public void DeleteAdditionalInfoShouldReturnTrue()
        {
            var controller = GetFunctionalEventController("info", "info");
            var @event = Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock()));
            controller.CreateEvent(@event);
            var info = AdditionalInfo.Mock();
            info.Event = @event;

            var result = controller.DeleteAdditionalInfo(@event.Id, info.Id);
            Assert.False(result == null, "Result should not be null");
        }

        [Fact]
        public void InvalidCommentValuesShouldReturnBadRequest()
        {
            var controller = GetFunctionalEventController("comment", "comment");
            var result = controller.CreateComment(Comment.Mock(), Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock())).Id);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DeleteCommentShouldReturnTrue()
        {
            var controller = GetFunctionalEventController("comment", "comment");
            var @event = Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock()));
            controller.CreateEvent(@event);
            var comment = Comment.Mock();
            comment.Event = @event;

            var result = controller.DeleteComment(@event.Id, comment.Id);
            Assert.False(result == null, "Result should not be null");
        }

        [Fact]
        public void InvalidFeedbackValuesShouldReturnBadRequest()
        {
            var controller = GetFunctionalEventController("feedback", "feedback");
            var result = controller.CreateFeedback(Feedback.Mock(), Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock())).Id);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DeleteFeedbackShouldReturnTrue()
        {
            var controller = GetFunctionalEventController("feedback", "feedback");
            var @event = Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock()));
            controller.CreateEvent(@event);
            var feedback = Feedback.Mock();
            feedback.Event = @event;

            var result = controller.DeleteFeedback(@event.Id, feedback.Id);
            Assert.False(result == null, "Result should not be null");
        }

        [Fact]
        public void InvalidActionLogValuesShouldReturnBadRequest()
        {
            var controller = GetFunctionalEventController("ActionLog", "ActionLog");
            var result = controller.CreateActionLog(ActionLog.Mock(Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock())), State.Mock()), Event.Mock(CheckType.Mock(), State.Mock(), Source.Mock(CheckType.Mock(), State.Mock())).Id);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
