using System;
using System.Linq;
using CheckCenter.Repositories.Interfaces;
using Domain;
using Domain.Archive;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckCenter.Repositories.EF
{
    public class EntityFrameworkActionLogRepository : EntityFrameworkRepository, IActionLogRepository
    {
        private readonly ArchiveDbContext _archive;

        public EntityFrameworkActionLogRepository(ProductionDbContext context, ArchiveDbContext archive) : base(context)
        {
            _archive = archive;
        }

        public int CreateActionLog(ActionLog actionLog)
        {
            actionLog = ValidateProperties(actionLog);
            var @event = Context.CheckCenterEvents
                .Include(e => e.State)
                .Where(e => e.Id == actionLog.Event.Id)
                .ToList()
                .First();
            actionLog.OldState = @event.State;
            actionLog.NewState = Context.CheckCenterStates.First(s => s.Id == actionLog.NewState.Id);
            actionLog.Event = @event;
            actionLog.Created = DateTime.Now;

            Context.CheckCenterActionLogs.Add(actionLog);
            Context.SaveChanges();

            return actionLog.Id;
        }

        public void ArchiveActionLog(ActionLog actionLog, int eventId)
        {
            var archivedActionLog = new ArchivedActionLog()
            {
                Created = actionLog.Created,
                EventId = eventId,
                UserEmail = actionLog.UserEmail,
                Id = actionLog.Id,
                NewStateId = actionLog.NewState.Id,
                OldStateId = actionLog.OldState.Id
            };
            _archive.CheckCenterActionLogs.Add(archivedActionLog);
            _archive.SaveChanges();
            
            Context.CheckCenterActionLogs.Remove(actionLog);
            Context.SaveChanges();
        }

        private ActionLog ValidateProperties(ActionLog actionLog)
        {
            if (actionLog.Event == null) throw new Exception("ActionLog model is invalid");
            // Assign properties
            actionLog.Event = Context.CheckCenterEvents.Find(actionLog.Event.Id);

            // Do not overwrite existing entities
            Context.Entry(actionLog.Event).State = EntityState.Unchanged;

            return actionLog;

        }
    }
}
