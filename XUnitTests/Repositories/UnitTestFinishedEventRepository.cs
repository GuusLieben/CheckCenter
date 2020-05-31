using System.Collections.Generic;
using System.Linq;
using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests {
    public class UnitTestFinishedEventRepository {

        [Fact]
        public void GetFinishedEventTest_AssertFalse()
        {
            var sourceRepo = GetSourceRepo("FinEvent_ProdTestDb");
            var typeRepo = GetTypeRepo("FinEvent_ProdTestDb");
            var stateRepo = GetStateRepo("FinEvent_ProdTestDb");
            var eventRepo = GetEventRepo("FinEvent_ProdTestDb", "FinEvent_ArchTestDb");
            var finEventRepo = GetFinishedEventRepo("FinEvent_ProdTestDb", "FinEvent_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @event = Event.Mock(checkType, state, source);
            eventRepo.CreateEvent(@event);
            eventRepo.DeleteEvent(@event, "");

            var result = finEventRepo.GetFinishedEvent(@event.Id);
            Assert.False(result == null, "Result should not be null");
        }

        [Fact]
        public void GetAllFinishedEventTest_AssertEqual()
        {
            var sourceRepo = GetSourceRepo("FinEvent_ProdTestDb");
            var typeRepo = GetTypeRepo("FinEvent_ProdTestDb");
            var stateRepo = GetStateRepo("FinEvent_ProdTestDb");
            var eventRepo = GetEventRepo("FinEvent_ProdTestDb", "FinEvent_ArchTestDb");
            var finEventRepo = GetFinishedEventRepo("FinEvent_ProdTestDb", "FinEvent_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @events = new List<Event>();

            for (int i = 0; i < 10; i++) {
                var temp = Event.Mock(checkType, state, source);
                eventRepo.CreateEvent(temp);
                @events.Add(temp);
                eventRepo.DeleteEvent(temp, "");
            }

            var result = finEventRepo.GetAllFinishedEvents();
            Assert.Equal(@events.Count, result.Count());
        }
        
    }
}