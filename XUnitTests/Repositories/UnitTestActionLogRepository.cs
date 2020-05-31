using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests
{
    public class UnitTestActionLogRepository
    {

        [Fact]
        public void CreateActionLogTest_AssertFalse()
        {
            var actionLogRepo = GetActionLogRepo("ActionLog_ProdTestDb", "ActionLog_ArchTestDb");
            var sourceRepo = GetSourceRepo("ActionLog_ProdTestDb");
            var typeRepo = GetTypeRepo("ActionLog_ProdTestDb");
            var stateRepo = GetStateRepo("ActionLog_ProdTestDb");
            var eventRepo = GetEventRepo("ActionLog_ProdTestDb", "ActionLog_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @event = Event.Mock(checkType, state, source);
            eventRepo.CreateEvent(@event);

            var result = actionLogRepo.CreateActionLog(ActionLog.Mock(@event, state));
            Assert.False(result == null, "ID should not be null");
        }
    }
}