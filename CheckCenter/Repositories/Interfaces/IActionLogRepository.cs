using Domain;

namespace CheckCenter.Repositories.Interfaces
{
    public interface IActionLogRepository
    {
        int CreateActionLog(ActionLog actionLog);
        void ArchiveActionLog(ActionLog actionlogId, int id);
    }
}
