using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public sealed class DataContext(DbContextOptions options) : DbContext(options)
{
    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<JobPost>()
            .HasOne(j => j.Company)
            .WithMany()
            .HasForeignKey(j => j.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<JobPost>()
            .HasOne(j => j.HiringManager)
            .WithMany(u => u.HiringPosts)
            .HasForeignKey(j => j.HiringManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Domain.Models.User>().HasData(SeedData.GetUserBaseData());
        modelBuilder.Entity<Domain.Models.Company>().HasData(SeedData.GetCompanyBaseData());
        modelBuilder.Entity<Domain.Models.JobPost>().HasData(SeedData.GetJobPostsBaseData());
    }

    public DbSet<Domain.Models.User> Users { get; set; }
    public DbSet<Domain.Models.JobPost> JobPosts { get; set; }
    public DbSet<Domain.Models.Company> Companies { get; set; }
}
