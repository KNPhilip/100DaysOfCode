namespace VideoGameManager.Data;

public sealed class DataContext(DbContextOptions options) : DbContext(options)
{
    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VideoGame>()
            .HasData(SeedData.VideoGames());
    }

    public DbSet<VideoGame> VideoGames { get; set; } = default!;
}
