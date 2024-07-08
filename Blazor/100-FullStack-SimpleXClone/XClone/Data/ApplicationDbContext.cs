using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XClone.Data.Domain;

namespace XClone.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.LikedTweets)
            .WithMany(t => t.LikedBy)
            .UsingEntity(j => j.ToTable("UserLikedTweets"));

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Retweets)
            .WithMany(t => t.RetweetedBy)
            .UsingEntity(j => j.ToTable("UserRetweets"));

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.QuotedTweets)
            .WithMany(t => t.QuotedBy)
            .UsingEntity(j => j.ToTable("UserQuotedTweets"));

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.BookmarkedTweet)
            .WithMany(t => t.BookmarkedBy)
            .UsingEntity(j => j.ToTable("UserBookmarkedTweets"));

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Followers)
            .WithMany(t => t.Following)
            .UsingEntity(j => j.ToTable("UserFollowings"));

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Tweets)
            .WithOne(t => t.Author);
    }

    public DbSet<Tweet> Tweets { get; set; }
}
