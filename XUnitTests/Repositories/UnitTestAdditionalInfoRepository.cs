using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests {
    public class UnitTestAdditionalInfoRepository {

        [Fact]
        public void CreateAdditionaInfo_AssertFalse() {
            var repo = GetAdditionalInfoRepo("Info_ProdTestDb", "Info_ArchTestDb");

            var result = repo.CreateAdditionalInfo(AdditionalInfo.Mock());
            Assert.False(result == null, "Result should not be null");
        }

        [Fact]
        public void UpdateAdditionalInfo_AssertTrue() {
            var repo = GetAdditionalInfoRepo("Info_ProdTestDb", "Info_ArchTestDb");

            var info = AdditionalInfo.Mock();
            repo.CreateAdditionalInfo(info);

            var result = repo.UpdateAdditionalInfo(info);
            Assert.True(result, "UpdateAdditionalInfo() should return true");
        }

        [Fact]
        public void DeleteAdditionalInfo_AssertTrue() {
            var repo = GetAdditionalInfoRepo("Info_ProdTestDb", "Info_ArchTestDb");

            var info = AdditionalInfo.Mock();
            repo.CreateAdditionalInfo(info);

            var result = repo.DeleteAdditionalInfo(info.Id);
            Assert.True(result, "DeleteAdditionalInfo() should return true");
        }

        [Fact]
        public void ArchiveAdditionalInfo() {
            var infoRepo = GetAdditionalInfoRepo("Info_ProdTestDb", "Info_ArchTestDb");
            var sourceRepo = GetSourceRepo("Info_ProdTestDb");
            var typeRepo = GetTypeRepo("Info_ProdTestDb");
            var stateRepo = GetStateRepo("Info_ProdTestDb");
            var eventRepo = GetEventRepo("Info_ProdTestDb", "Info_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @event = Event.Mock(checkType, state, source);
            eventRepo.CreateEvent(@event);
            var info = AdditionalInfo.Mock();
            info.Event = @event;
            infoRepo.CreateAdditionalInfo(info);

            infoRepo.ArchiveAdditionalInfo(info, @event.Id);
        }
    }
}