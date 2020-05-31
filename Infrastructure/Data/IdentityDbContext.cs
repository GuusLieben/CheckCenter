using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var defaultUser = new User() { FirstName="NOC", LastName="Monitoring", Password="1234", UserEmail = "admin@cm.com"};
            modelBuilder.Entity<User>().HasData(defaultUser);
        }

        public DbSet<User> Users { get; set; }
    }
}
