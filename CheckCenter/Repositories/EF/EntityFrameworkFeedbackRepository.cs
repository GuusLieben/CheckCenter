using System;
using CheckCenter.Repositories.Interfaces;
using Domain;
using Domain.Archive;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CheckCenter.Repositories.EF {
    public class EntityFrameworkFeedbackRepository : EntityFrameworkRepository, IFeedbackRepository {
        private readonly ArchiveDbContext _archive;

        public EntityFrameworkFeedbackRepository(ProductionDbContext context, ArchiveDbContext archive) : base(context)
        {
            _archive = archive;
        }

        public int CreateFeedback(Feedback feedback) {
            feedback = ValidateProperties(feedback);
            Context.CheckCenterFeedback.Add(feedback);
            Context.SaveChanges();

            return feedback.Id;
        }

        public bool DeleteFeedback(int id) {
            try {
                var feedback = new Feedback {Id = id};
                Context.CheckCenterFeedback.Attach(feedback);
                Context.CheckCenterFeedback.Remove(feedback);
                Context.SaveChanges();

                return true;
            } catch {
                return false;
            }
            
        }

        public void ArchiveFeedback(Feedback feedback, int id)
        {
            
            var archivedFeedback = new ArchivedFeedback()
            {
                Content = feedback.Content,
                Created = feedback.Created,
                EventId = id,
                Id = feedback.Id,
                UserEmail = feedback.UserEmail
            };
            _archive.CheckCenterFeedback.Add(archivedFeedback);
            _archive.SaveChanges();

            DeleteFeedback(feedback.Id);
        }

        private Feedback ValidateProperties(Feedback feedback) {
            if (feedback.Event == null) throw new System.Exception("Feedback model is invalid");
            // Assign properties
            feedback.Event = Context.CheckCenterEvents.Find(feedback.Event.Id);

            // Do not overwrite existing entities
            Context.Entry(feedback.Event).State = EntityState.Unchanged;
            return feedback;
        }
    }
}
