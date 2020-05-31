using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests {
    public class UnitTestFeedbackRepository {

        [Fact]
        public void CreateFeedbackTest_AssertFalse() {
            var feedbackRepo = GetFeedbackRepo("Feedback_ProdTestDb", "Feedback_ArchTestDb");
            var sourceRepo = GetSourceRepo("Feedback_ProdTestDb");
            var typeRepo = GetTypeRepo("Feedback_ProdTestDb");
            var stateRepo = GetStateRepo("Feedback_ProdTestDb");
            var eventRepo = GetEventRepo("Feedback_ProdTestDb", "Feedback_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @event = Event.Mock(checkType, state, source);
            eventRepo.CreateEvent(@event);
            var feedback = Feedback.Mock();
            feedback.Event = @event;

            var result = feedbackRepo.CreateFeedback(feedback);
            Assert.False(result == null, "Result should not be null");
        }

        [Fact]
        public void DeleteFeedbackTest_AssertFalse() {
            var repo = GetFeedbackRepo("Feedback_ProdTestDb", "Feedback_ArchTestDb");
            var feedback = Feedback.Empty();

            var result = repo.DeleteFeedback(feedback.Id);
            Assert.False(result, "FeedbackComment() should return false, as it can not delete feedback that hasn't been created");
        }

        [Fact]
        public void ArchiveFeedbackTest()
        {
            var feedbackRepo = GetFeedbackRepo("Comment_ProdTestDb", "Comment_ArchTestDb");
            var sourceRepo = GetSourceRepo("Comment_ProdTestDb");
            var typeRepo = GetTypeRepo("Comment_ProdTestDb");
            var stateRepo = GetStateRepo("Comment_ProdTestDb");
            var eventRepo = GetEventRepo("Comment_ProdTestDb", "Comment_ArchTestDb");

            var checkType = CheckType.Mock();
            typeRepo.CreateType(checkType);
            var state = State.Mock();
            stateRepo.CreateState(state);
            var source = Source.Mock(checkType, state);
            sourceRepo.CreateSource(source);
            var @event = Event.Mock(checkType, state, source);
            eventRepo.CreateEvent(@event);
            var feedback = Feedback.Mock();
            feedback.Event = @event;
            feedbackRepo.CreateFeedback(feedback);

            feedbackRepo.ArchiveFeedback(feedback, @event.Id);
        }
    }
}