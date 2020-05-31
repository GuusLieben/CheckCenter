using Domain;

namespace CheckCenter.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        int CreateComment(Comment comment);

        bool DeleteComment(int id);
        void ArchiveComment(Comment comment, int id);
    }
}
