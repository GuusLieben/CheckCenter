using System.Collections.Generic;
using System.Linq;
using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests
{
    public class UnitTestSourceRepository
    {
        [Fact]
        public void CreateSourceTest_AssertFalse() {
            var sourceRepo = GetSourceRepo("Source_TestDb");
            var typeRepo = GetTypeRepo("Source_TestDb");
            var stateRepo = GetStateRepo("Source_TestDb");

            var checkType = CheckType.Mock();
            var state = State.Mock();

            typeRepo.CreateType(checkType);
            stateRepo.CreateState(state);
            var result = sourceRepo.CreateSource(Source.Mock(checkType, state));

            Assert.False(result == null, "ID shouldn't be null");
        }

        [Fact]
        public void GetSourceTest_AssertTrue() {
            var sourceRepo = GetSourceRepo("Source_TestDb");
            var typeRepo = GetTypeRepo("Source_TestDb");
            var stateRepo = GetStateRepo("Source_TestDb");

            var checkType = CheckType.Mock();
            var state = State.Mock();
            var source = Source.Mock(checkType, state);

            typeRepo.CreateType(checkType);
            stateRepo.CreateState(state);
            sourceRepo.CreateSource(source);

            var result = sourceRepo.GetSource(source.Id);
            Assert.True(result.Id == source.Id, "GetSource() ID must be the same as the objects (source) ID ");
        }

        [Fact]
        public void GetAllSourcesTest_AssertTrue() {
            var sourceRepo = GetSourceRepo("Source_TestDb");
            var typeRepo = GetTypeRepo("Source_TestDb");
            var stateRepo = GetStateRepo("Source_TestDb");

            var checkType = CheckType.Mock();
            var state = State.Mock();
            var sources = new List<Source>();

            typeRepo.CreateType(checkType);
            stateRepo.CreateState(state);

            for (int i = 0; i < 10; i++) {
                var temp = Source.Mock(checkType, state);
                sourceRepo.CreateSource(temp);
                sources.Add(temp);
            }

            var result = sourceRepo.GetAllSources();
            Assert.True(sources.Count == result.Count(), "GetAllSources() should have as much objects as var sources");
        }

        [Fact]
        public void UpdateSourceTest_AssertTrue()
        {
            var sourceRepo = GetSourceRepo("Source_TestDb");
            var typeRepo = GetTypeRepo("Source_TestDb");
            var stateRepo = GetStateRepo("Source_TestDb");

            var checkType = CheckType.Mock();
            var state = State.Mock();
            var source = Source.Mock(checkType, state);

            typeRepo.CreateType(checkType);
            stateRepo.CreateState(state);
            sourceRepo.CreateSource(source);

            var updatedSource = sourceRepo.GetSource(source.Id);
            updatedSource.SetDisplayName("This is an updated object");

            var result = sourceRepo.UpdateSource(updatedSource);
            Assert.True(result, "UpdateSource() should return true");
        }

        [Fact]
        public void DeleteSourceTest_AssertTrue() {
            var sourceRepo = GetSourceRepo("Source_TestDb");
            var typeRepo = GetTypeRepo("Source_TestDb");
            var stateRepo = GetStateRepo("Source_TestDb");

            var checkType = CheckType.Mock();
            var state = State.Mock();
            var source = Source.Mock(checkType, state);

            typeRepo.CreateType(checkType);
            stateRepo.CreateState(state);
            sourceRepo.CreateSource(source);

            var result = sourceRepo.DeleteSource(sourceRepo.GetSource(source.Id));
            Assert.True(result, "DeleteSource() should return true");
        }
    }
}
