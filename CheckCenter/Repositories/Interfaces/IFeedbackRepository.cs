using Domain;

namespace CheckCenter.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        int CreateFeedback(Feedback feedback);

        bool DeleteFeedback(int id);
        void ArchiveFeedback(Feedback feedback, int id);
    }
}
