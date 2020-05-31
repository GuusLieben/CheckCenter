using System;
using System.Linq;
using CheckCenter.Repositories.Interfaces;
using Domain;
using Domain.Archive;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CheckCenter.Repositories.EF
{
    public class EntityFrameworkCommentRepository : EntityFrameworkRepository, ICommentRepository {
        private readonly ArchiveDbContext _archive;

        public EntityFrameworkCommentRepository(ProductionDbContext context, ArchiveDbContext archive) : base(context)
        {
            _archive = archive;
        }

        public int CreateComment(Comment comment) {
            comment = ValidateProperties(comment);
            Context.CheckCenterComments.Add(comment);
            Context.SaveChanges();
            return comment.Id;
        }

        public bool DeleteComment(int id) {
            try {
                var comment = new Comment {Id = id};
                Context.CheckCenterComments.Attach(comment);
                Context.CheckCenterComments.Remove(comment);
                Context.SaveChanges();

                return true;
            } catch {
                return false;
            }
            
        }

        public void ArchiveComment(Comment comment, int eventId)
        {
            var archivedEvent = new ArchivedComment()
            {
                Content = comment.Content,
                Created = comment.Created,
                EventId = eventId,
                Id = comment.Id,
                UserEmail = comment.UserEmail
            };
            _archive.CheckCenterComments.Add(archivedEvent);
            _archive.SaveChanges();

            DeleteComment(comment.Id);
        }

        private Comment ValidateProperties(Comment comment) {
            if (comment.Event == null) throw new System.Exception("Comment model is invalid");
            // Assign properties
            comment.Event = Context.CheckCenterEvents.Find(comment.Event.Id);

            // Do not overwrite existing entities
            Context.Entry(comment.Event).State = EntityState.Unchanged;
            return comment;
        }
    }
}
