using System.Collections.Generic;
using Domain.Archive;

namespace CheckCenter.Repositories.Interfaces
{
    public interface IFinishedEventRepository {
        IEnumerable<ReturnableEvent> GetAllFinishedEvents();

        ReturnableEvent GetFinishedEvent(int id);
    }
}

