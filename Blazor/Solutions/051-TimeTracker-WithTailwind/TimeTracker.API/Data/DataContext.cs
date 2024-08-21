using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Data
{
    public sealed class DataContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Navigation(p => p.ProjectDetails).AutoInclude();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDetails> ProjectDetails { get; set; }
    }
}
