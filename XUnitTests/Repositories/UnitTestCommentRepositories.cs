using Domain;
using Xunit;
using static XUnitTests.UnitTestRepository;

namespace XUnitTests {
    public class UnitTestCommentRepositories {

        [Fact]
        public void CreateCommentTest_AssertFalse() {
            var commentRepo = GetCommentRepo("Comment_ProdTestDb", "Comment_ArchTestDb");
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
            var comment = Comment.Mock();
            comment.Event = @event;

            var result = commentRepo.CreateComment(comment);
            Assert.False(result == null, "Result should not be null");
        }

        [Fact]
        public void DeleteCommentTest_AssertFalse() {
            var commentRepo = GetCommentRepo("Comment_ProdTestDb", "Comment_ArchTestDb");
            var comment = Comment.Empty();

            var result = commentRepo.DeleteComment(comment.Id);
            Assert.False(result,
                "DeleteComment() should return false, as it can not delete a comment that hasn't been created");
        }

        [Fact]
        public void ArchiveCommentTest() {
            var commentRepo = GetCommentRepo("Comment_ProdTestDb", "Comment_ArchTestDb");
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
            var comment = Comment.Mock();
            comment.Event = @event;
            commentRepo.CreateComment(comment);

            commentRepo.ArchiveComment(comment, @event.Id);
        }
    }
}