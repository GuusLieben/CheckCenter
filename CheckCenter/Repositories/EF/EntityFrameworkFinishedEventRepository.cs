using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CheckCenter.Repositories.Interfaces;
using Domain.Archive;
using Infrastructure.Data;

namespace CheckCenter.Repositories.EF
{
    public class EntityFrameworkFinishedEventRepository : EntityFrameworkRepository, IFinishedEventRepository
    {
        private readonly ArchiveDbContext _archive;

        public EntityFrameworkFinishedEventRepository(ProductionDbContext context, ArchiveDbContext archive) : base(context)
        {
            _archive = archive;
        }

        public IEnumerable<ReturnableEvent> GetAllFinishedEvents()
        {
            var unconvertedEvents = _archive.CheckCenterFinishedEvents.ToList();
            var convertedEvents = new List<ReturnableEvent>();
            unconvertedEvents.ForEach(ue => convertedEvents.Add(ConvertEvent(ue)));
            return convertedEvents;
        }

        public ReturnableEvent GetFinishedEvent(int id)
        {
            var archivedEvent = _archive.CheckCenterFinishedEvents.First(fe => fe.Id == id);
            return ConvertEvent(archivedEvent, true);
        }

        private ReturnableEvent ConvertEvent(ArchivedEvent archivedEvent, bool allData = false)
        {
            var @event = new ReturnableEvent()
            {
                Id = archivedEvent.Id,
                Added = archivedEvent.Added,
                Updated = archivedEvent.Updated,
                Title = archivedEvent.Title,
                Description = archivedEvent.Description,
                Conclusion = archivedEvent.Conclusion,
                EventSeverity = archivedEvent.EventSeverity,
                Shorthand = archivedEvent.Shorthand,
                Finished = archivedEvent.Finished == DateTime.MinValue ? null : archivedEvent.Finished.ToString(CultureInfo.CurrentCulture),
                Removed = archivedEvent.Removed == DateTime.MinValue ? null : archivedEvent.Removed.ToString(CultureInfo.CurrentCulture),
            };

            if (!allData) return @event;
            
            var comments = _archive.CheckCenterComments
                .Where(c => c.EventId == @event.Id)
                .ToList();
            @event.Comments = comments;

            var feedback = _archive.CheckCenterFeedback
                .Where(c => c.EventId == @event.Id)
                .ToList();
            @event.Feedback = feedback;

            var actionLogs = _archive.CheckCenterActionLogs
                .Where(c => c.EventId == @event.Id)
                .ToList();
            @event.ActionLogs = actionLogs;

            var info = _archive.CheckCenterAdditionalInfo
                .Where(c => c.EventId == @event.Id)
                .ToList();
            @event.AdditionalInfo = info;

            @event.Source = Context.CheckCenterSources.First(s => s.Id == archivedEvent.SourceId);
            @event.State = Context.CheckCenterStates.First(s => s.Id == archivedEvent.StateId);
            @event.CheckType = Context.CheckCenterCheckTypes.First(t => t.Id == archivedEvent.CheckTypeId);

            return @event;
        }
    }
}
