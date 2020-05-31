using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductionDbContext : DbContext
    {
        
        public ProductionDbContext(DbContextOptions<ProductionDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().HasMany(e => e.ActionLogs).WithOne().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ActionLog>().HasOne(al => al.NewState).WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ActionLog>().HasOne(al => al.OldState).WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>().HasMany(e => e.AdditionalInfo).WithOne().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>().HasMany(e => e.Comments).WithOne().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>().HasMany(e => e.Feedback).WithOne().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>().HasOne(e => e.Source).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Event>().HasOne(e => e.CheckType).WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Event>().HasOne(e => e.State).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Source>().HasMany(s => s.States).WithOne().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Source>().HasOne(s => s.CheckType).WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            var checkType1 = new
            {
                Id = 1,
                Description = "An AX instance type",
                Title = "AXInstance"
            };

            var source1 = new
            {
                Id = 4,
                Active = true,
                CheckCenterServiceId = 110,
                CheckTypeId = checkType1.Id,
                Color = "Yellow",
                ComebackDelay = 5000,
                ConnectionString = "msssql://sample",
                DisplayName = "AX Amsterdam",
                IsCustomerSource = true,
                IsStacked = true,
                LogActionMandatory = false,
                Order = 550,
                SourceSeverity = 500
            };

            var state1 = new
            {
                Id = 2,
                Description = "Issue is under investigation",
                Title = "Under investigation",
                SourceId = source1.Id
            };
            var state2 = new
            {
                Id = 3,
                Description = "Issue marked as duplicate",
                Title = "Duplicate",
                SourceId = source1.Id
            };


            var event1 = new
            {
                Id = 5,
                Added = DateTime.Now,
                Updated = DateTime.Now,
                CheckTypeId = checkType1.Id,
                Description = "Ods - Breda/Warn: 1 MTs missing from Oltp",
                EventSeverity = 300,
                Shorthand = "s0sd009ds",
                SourceId = source1.Id,
                StateId = state2.Id,
                Title = "Ods -1MTs from Oltp"
            };

            var actionLog1 = new
            {
                Id = 6,
                Created = DateTime.Now,
                EventId = event1.Id,
                NewStateId = state1.Id,
                UserEmail = "tvw203@gmail.com"
            };
            var actionLog2 = new
            {
                Id = 7,
                Created = DateTime.Now,
                EventId = event1.Id,
                NewStateId = state2.Id,
                OldStateId = state1.Id,
                UserEmail = "tvw203@gmail.com"
            };

            var feedback1 = new
            {
                Id = 8,
                Content = "@gli23 you didn't mark the issue as recurring",
                Created = DateTime.Now,
                EventId = event1.Id,
                UserEmail = "tvw203@gmail.com"
            };
            var feedback2 = new
            {
                Id = 9,
                Content = "@gli23 you didn't update the state to UI",
                Created = DateTime.Now,
                EventId = event1.Id,
                UserEmail = "iemand@gmail.com"
            };

            var comment1 = new
            {
                Id = 10,
                Content = "Recurring issue, cause known but no fix available yet",
                Created = DateTime.Now,
                EventId = event1.Id,
                UserEmail = "tvw203@gmail.com"
            };
            var comment2 = new
            {
                Id = 11,
                Content = "Snoozed issue for 36 hours",
                Created = DateTime.Now,
                EventId = event1.Id,
                UserEmail = "tvw203@gmail.com"
            };

            var info1 = new
            {
                Id = 12,
                EventId = event1.Id,
                Key = "SourceServiceId",
                Value = "1738"
            };
            var info2 = new
            {
                Id = 13,
                EventId = event1.Id,
                Key = "Supplier",
                Value = "15 - Pathfinder"
            };
            var info3 = new
            {
                Id = 13,
                EventId = event1.Id,
                Key = "Country",
                Value = "HU"
            };
            var info4 = new
            {
                Id = 13,
                EventId = event1.Id,
                Key = "FailedRequests",
                Value = "1103"
            };
            var info5 = new
            {
                Id = 13,
                EventId = event1.Id,
                Key = "SuccessfulRetries",
                Value = "1103"
            };

            modelBuilder.Entity<CheckType>().HasData(checkType1);
            modelBuilder.Entity<State>().HasData(state1, state2);
            modelBuilder.Entity<Source>().HasData(source1);
            modelBuilder.Entity<Event>().HasData(event1);
            modelBuilder.Entity<ActionLog>().HasData(actionLog1, actionLog2);
            modelBuilder.Entity<Feedback>().HasData(feedback1, feedback2);
            modelBuilder.Entity<Comment>().HasData(comment1, comment2);
            modelBuilder.Entity<AdditionalInfo>().HasData(info1, info2, info3, info4, info5);
        }


        public DbSet<Event> CheckCenterEvents { get; set; }
        public DbSet<ActionLog> CheckCenterActionLogs { get; set; }
        public DbSet<AdditionalInfo> CheckCenterAdditionalInfo { get; set; }
        public DbSet<Comment> CheckCenterComments { get; set; }
        public DbSet<Feedback> CheckCenterFeedback { get; set; }
        public DbSet<Source> CheckCenterSources { get; set; }
        public DbSet<State> CheckCenterStates { get; set; }
        public DbSet<CheckType> CheckCenterCheckTypes { get; set; }
    }
}
