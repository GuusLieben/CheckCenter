using System;
using System.Collections.Generic;
using Domain;

namespace CheckCenter.Repositories.Interfaces
{
    public interface IEventRepository
    {
        IEnumerable<IGenericEvent> GetAllEvents();

        IGenericEvent GetEvent(int id);

        IEnumerable<Event> GetAllUpdatedEventsSince(DateTime dateTime);

        int CreateEvent(Event @event);
        bool UpdateEvent(Event @event, string UserEmail);
        bool DeleteEvent(Event @event, string conclusion, bool finished = false);
        void SetLastUpdated(Event @event);

        void SetLastUpdated(int eventId);
    }
}
