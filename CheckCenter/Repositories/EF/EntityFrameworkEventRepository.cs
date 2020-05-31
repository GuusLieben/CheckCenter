using System;
using System.Collections.Generic;
using System.Linq;
using CheckCenter.Repositories.Interfaces;
using Domain;
using Domain.Archive;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace CheckCenter.Repositories.EF
{
    public class EntityFrameworkEventRepository : EntityFrameworkRepository, IEventRepository
    {
        private readonly ArchiveDbContext _archive;
        private readonly EntityFrameworkActionLogRepository _actionLogRepository;

        public EntityFrameworkEventRepository(ProductionDbContext context,
            ArchiveDbContext archive) : base(context)
        {
            _archive = archive;
            var actionLogRepository = new EntityFrameworkActionLogRepository(context, archive);
            _actionLogRepository = actionLogRepository;
        }

        public int CreateEvent(Event @event)
        {
            @event = ValidateProperties(@event);
            @event.Updated = DateTime.Now;
            Context.CheckCenterEvents.Add(@event);
            Context.SaveChanges();
            return @event.Id;
        }

        public IEnumerable<Event> GetAllUpdatedEventsSince(DateTime dateTime)
        {
            // Include updates
            Console.WriteLine("Looking for changes after : " + dateTime);
            var activeUpdated = Context.CheckCenterEvents
                .Where(e => e.Updated.CompareTo(dateTime) > 0)
                .Include(e => e.CheckType)
                .Include(e => e.Source)
                .ThenInclude(s => s.States)
                .Include(e => e.State)
                .ToList();

            var events = new List<Event>();

            activeUpdated.ForEach(@event =>
            {
                var comments = Context.CheckCenterComments
                    .Where(c => c.Event.Id == @event.Id)
                    .ToList();
                comments.ForEach(c => c.Event = null);
                @event.Comments = comments;

                var feedback = Context.CheckCenterFeedback
                    .Where(c => c.Event.Id == @event.Id)
                    .ToList();
                feedback.ForEach(c => c.Event = null);
                @event.Feedback = feedback;

                var actionLogs = Context.CheckCenterActionLogs
                    .Where(c => c.Event.Id == @event.Id)
                    .ToList();
                actionLogs.ForEach(c => c.Event = null);
                @event.ActionLogs = actionLogs;

                var info = Context.CheckCenterAdditionalInfo
                    .Where(c => c.Event.Id == @event.Id)
                    .ToList();
                info.ForEach(c => c.Event = null);
                @event.AdditionalInfo = info;

                events.Add(@event);
            });

            return events;
        }

        public IEnumerable<IGenericEvent> GetAllEvents()
        {
            return Context.CheckCenterEvents
                .Include(e => e.CheckType)
                .Include(e => e.Source)
                .Include(e => e.State)
                .ToList();
        }

        public IGenericEvent GetEvent(int id)
        {
            var @event = Context.CheckCenterEvents.Where(e => e.Id == id)
                .Include(e => e.CheckType)
                .Include(e => e.Source).ThenInclude(s => s.States)
                .Include(e => e.State)
                .Include(e => e.Comments)
                .ToList()
                .FirstOr(Event.Empty());

            var comments = Context.CheckCenterComments
                .Where(c => c.Event.Id == @event.Id)
                .ToList();
            comments.ForEach(c => c.Event = null);
            @event.Comments = comments;

            var feedback = Context.CheckCenterFeedback
                .Where(c => c.Event.Id == @event.Id)
                .ToList();
            feedback.ForEach(c => c.Event = null);
            @event.Feedback = feedback;

            var actionLogs = Context.CheckCenterActionLogs
                .Where(c => c.Event.Id == @event.Id)
                .ToList();
            actionLogs.ForEach(c => c.Event = null);
            @event.ActionLogs = actionLogs;

            var info = Context.CheckCenterAdditionalInfo
                .Where(c => c.Event.Id == @event.Id)
                .ToList();
            info.ForEach(c => c.Event = null);
            @event.AdditionalInfo = info;

            return @event;
        }

        public bool UpdateEvent(Event @event, string UserEmail)
        {
            var dbEvent = (Event) GetEvent(@event.Id);

            if (@event.State != null)
            {
                var state = dbEvent.Source.States.First(s => s.Id == @event.State.Id);
                if (state != null)
                {
                    if (state.Id != dbEvent.State.Id && UserEmail != null && !UserEmail.Equals(""))
                    {
                        var log = new ActionLog()
                        {
                            Created = DateTime.Now,
                            Event = dbEvent,
                            NewState = state,
                            OldState = dbEvent.State,
                            UserEmail = UserEmail
                        };
                        _actionLogRepository.CreateActionLog(log);
                    }

                    dbEvent.State = state;
                }
            }

            var entry = Context.Entry(dbEvent);
            dbEvent.Updated = DateTime.Now;

            entry.Property(e => e.Added).IsModified = false;

            if (@event.Title != null)
            {
                dbEvent.Title = @event.Title;
                entry.Property(e => e.Title).IsModified = true;
            }

            if (@event.Description != null)
            {
                dbEvent.Description = @event.Description;
                entry.Property(e => e.Description).IsModified = true;
            }

            if (@event.Shorthand != null)
            {
                dbEvent.Shorthand = @event.Shorthand;
                entry.Property(e => e.Shorthand).IsModified = true;
            }

            if (@event.EventSeverity != 0)
            {
                dbEvent.EventSeverity = @event.EventSeverity;
                entry.Property(e => e.EventSeverity).IsModified = true;
            }

            foreach (var eventProp in dbEvent.Comments)
            {
                var tempEntry = Context.Entry(eventProp);
                tempEntry.Entity.Event = entry.Entity;
                tempEntry.Reference(t => t.Event).IsModified = true;
            }

            foreach (var eventProp in dbEvent.Feedback)
            {
                var tempEntry = Context.Entry(eventProp);
                tempEntry.Entity.Event = entry.Entity;
                tempEntry.Reference(t => t.Event).IsModified = true;
            }

            foreach (var eventProp in dbEvent.ActionLogs)
            {
                var tempEntry = Context.Entry(eventProp);
                tempEntry.Entity.Event = entry.Entity;
                tempEntry.Reference(t => t.Event).IsModified = true;
            }

            foreach (var eventProp in dbEvent.AdditionalInfo)
            {
                var tempEntry = Context.Entry(eventProp);
                tempEntry.Entity.Event = entry.Entity;
                tempEntry.Reference(t => t.Event).IsModified = true;
            }

            Context.SaveChanges();
            return true;
        }

        public bool DeleteEvent(Event @event, string conclusion, bool finished = false)
        {
            try
            {
                Context.CheckCenterEvents.Attach(@event);

                ArchiveEvent((Event) GetEvent(@event.Id), finished, conclusion);

                Context.CheckCenterEvents.Remove(@event);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("=============== Error : " + ex.Message);
                return false;
            }
        }

        private void ArchiveEvent(Event @event, bool finished, string conclusion)
        {
            var archivedEvent = new ArchivedEvent()
            {
                Id = @event.Id,
                Added = @event.Added,
                Updated = @event.Updated,
                Title = @event.Title,
                Description = @event.Description,
                EventSeverity = @event.EventSeverity,
                Shorthand = @event.Shorthand,
                SourceId = @event.Source.Id,
                StateId = @event.State.Id,
                CheckTypeId = @event.CheckType.Id
            };

            if (!conclusion.Equals(""))
            {
                archivedEvent.Conclusion = conclusion;
            }

            if (finished)
            {
                archivedEvent.Finished = DateTime.Now;
                archivedEvent.Removed = DateTime.MinValue;
            }
            else
            {
                archivedEvent.Removed = DateTime.Now;
                archivedEvent.Finished = DateTime.MinValue;
            }

            _archive.CheckCenterFinishedEvents.Add(archivedEvent);
            _archive.SaveChanges();
        }

        private Event ValidateProperties(Event @event)
        {
            if (@event.Source == null || @event.State == null || @event.CheckType == null)
                throw new Exception("Event model is invalid");

            // Assign properties
            @event.Source = Context.CheckCenterSources.Find(@event.Source.Id);
            @event.State = Context.CheckCenterStates.Find(@event.State.Id);
            @event.CheckType = Context.CheckCenterCheckTypes.Find(@event.CheckType.Id);

            // Do not overwrite existing entities
            Context.Entry(@event.Source).State = EntityState.Unchanged;
            Context.Entry(@event.State).State = EntityState.Unchanged;
            Context.Entry(@event.CheckType).State = EntityState.Unchanged;

            return @event;
        }

        public void SetLastUpdated(int eventId)
        {
            SetLastUpdated(new Event {Id = eventId});
        }

        public void SetLastUpdated(Event @event)
        {
            UpdateEvent(@event, null);
        }
    }
}