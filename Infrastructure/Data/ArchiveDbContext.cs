using System;
using Domain.Archive;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ArchiveDbContext : DbContext {

        public ArchiveDbContext(DbContextOptions<ArchiveDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var event1 = new
            {
                StoredId = 1,
                Id = 1,
                Added = DateTime.Now,
                Updated = DateTime.Now,
                CheckTypeId = 1,
                Description = "Ods - Breda/Warn: 1 MTs missing from Oltp",
                EventSeverity = 300,
                Shorthand = "s0sd009ds",
                SourceId = 4,
                StateId = 2,
                Title = "Ods -1MTs from Oltp",
                Finished = DateTime.Now,
                Removed = DateTime.MinValue
            };
            var actionLog1 = new
            {
                StoredId = 1,
                Id = 1,
                Created = DateTime.Now,
                EventId = event1.Id,
                NewStateId = 2,
                OldStateId = -1,
                UserEmail = "tvw203@gmail.com"
            };
            var actionLog2 = new
            {

                StoredId = 2,
                Id = 2,
                Created = DateTime.Now,
                EventId = event1.Id,
                NewStateId = 3,
                OldStateId = 2,
                UserEmail = "tvw203@gmail.com"
            };

            var feedback1 = new
            {
                StoredId = 1,
                Id = 1,
                Content = "@gli23 you didn't mark the issue as recurring",
                Created = DateTime.Now,
                EventId = event1.Id,
                UserEmail = "tvw203@gmail.com"
            };
            var feedback2 = new
            {
                StoredId = 2,
                Id = 2,
                Content = "@gli23 you didn't update the state to UI",
                Created = DateTime.Now,
                EventId = event1.Id,
                UserEmail = "iemand@gmail.com"
            };

            var comment1 = new
            {
                StoredId = 1,
                Id = 1,
                Content = "Recurring issue, cause known but no fix available yet",
                Created = DateTime.Now,
                EventId = event1.Id,
                UserEmail = "tvw203@gmail.com"
            };
            var comment2 = new
            {
                StoredId = 2,
                Id = 2,
                Content = "Snoozed issue for 36 hours",
                Created = DateTime.Now,
                EventId = event1.Id,
                UserEmail = "tvw203@gmail.com"
            };

            var info1 = new
            {
                StoredId = 1,
                Id = 1,
                EventId = event1.Id,
                Key = "Amount of tickets",
                Value = "0"
            };
            var info2 = new
            {
                StoredId = 2,
                Id = 2,
                EventId = event1.Id,
                Key = "Location",
                Value = "Amsterdam"
            };

            modelBuilder.Entity<ArchivedEvent>().HasData(event1);
            modelBuilder.Entity<ArchivedActionLog>().HasData(actionLog1, actionLog2);
            modelBuilder.Entity<ArchivedFeedback>().HasData(feedback1, feedback2);
            modelBuilder.Entity<ArchivedComment>().HasData(comment1, comment2);
            modelBuilder.Entity<ArchivedInfo>().HasData(info1, info2);
        }

        public DbSet<ArchivedActionLog> CheckCenterActionLogs { get; set; }
        public DbSet<ArchivedInfo> CheckCenterAdditionalInfo { get; set; }
        public DbSet<ArchivedComment> CheckCenterComments { get; set; }
        public DbSet<ArchivedEvent> CheckCenterFinishedEvents { get; set; }
        public DbSet<ArchivedFeedback> CheckCenterFeedback { get; set; }
    }
}
