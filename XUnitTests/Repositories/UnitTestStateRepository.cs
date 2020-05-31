using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests
{
    public class UnitTestStateRepository
    {

        [Fact]
        public void CreateStateTest_ReturnFalse()
        {
            var stateRepo = GetStateRepo("State_TestDb");
            var result = stateRepo.CreateState(State.Empty());

            Assert.False(result == null, "ID shouldn't be null");
        }
    }
}