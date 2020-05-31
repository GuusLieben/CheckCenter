using System.Collections.Generic;
using System.Linq;
using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests
{
    public class UnitTestEventRepository
    {

        [Fact]
        public void CreateEventTest_AssertFalse()
        {
            var sourceRepo = GetSourceRepo("Event_ProdTestDb");
            var typeRepo = GetTypeRepo("Event_ProdTestDb");
            var stateRepo = GetStateRepo("Event_ProdTestDb");
            var eventRepo = GetEventRepo("Event_ProdTestDb", "Event_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);

            var result = eventRepo.CreateEvent(Event.Mock(checkType, state, source));
            Assert.False(result == null, "CreateEvent() should return an ID");
        }

        [Fact]
        public void GetEventTest_AssertEqual()
        {
            var sourceRepo = GetSourceRepo("Event_ProdTestDb");
            var typeRepo = GetTypeRepo("Event_ProdTestDb");
            var stateRepo = GetStateRepo("Event_ProdTestDb");
            var eventRepo = GetEventRepo("Event_ProdTestDb", "Event_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @event = Event.Mock(checkType, state, source);
            eventRepo.CreateEvent(@event);

            var result = eventRepo.GetEvent(@event.Id);
            Assert.Equal(@event.Id, result.Id);
        }

        [Fact]
        public void GetAllEventsTest_AssertEqual()
        {
            var sourceRepo = GetSourceRepo("Event_ProdTestDb");
            var typeRepo = GetTypeRepo("Event_ProdTestDb");
            var stateRepo = GetStateRepo("Event_ProdTestDb");
            var eventRepo = GetEventRepo("Event_ProdTestDb", "Event_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @events = new List<Event>();

            for (int i = 0; i < 10; i++)
            {
                var temp = Event.Mock(checkType, state, source);
                eventRepo.CreateEvent(temp);
                @events.Add(temp);
            }

            var result = eventRepo.GetAllEvents();
            Assert.Equal(@events.Count, result.Count());
        }

        [Fact]
        public void UpdateEventTest_AssertTrue()
        {
            var sourceRepo = GetSourceRepo("Event_ProdTestDb");
            var typeRepo = GetTypeRepo("Event_ProdTestDb");
            var stateRepo = GetStateRepo("Event_ProdTestDb");
            var eventRepo = GetEventRepo("Event_ProdTestDb", "Event_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @event = Event.Mock(checkType, state, source);
            eventRepo.CreateEvent(@event);

            var updatedEvent = eventRepo.GetEvent(@event.Id);
            updatedEvent.SetTitle("This is an updated object");

            var result = eventRepo.UpdateEvent((Event)updatedEvent, "test@test.test");
            Assert.True(result, "UpdateEvent() should return true");
        }

        [Fact]
        public void DeleteEventTest_AssertTrue()
        {
            var sourceRepo = GetSourceRepo("Event_ProdTestDb");
            var typeRepo = GetTypeRepo("Event_ProdTestDb");
            var stateRepo = GetStateRepo("Event_ProdTestDb");
            var eventRepo = GetEventRepo("Event_ProdTestDb", "Event_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @event = Event.Mock(checkType, state, source);
            eventRepo.CreateEvent(@event);

            var result = eventRepo.DeleteEvent(@event, "");
            Assert.True(result, "DeleteEvent() should return true");
        }
    }
}
