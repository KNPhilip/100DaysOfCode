namespace FullStack.Data;

public sealed class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VideoGame>()
            .HasData(SeedData.VideoGames());

        modelBuilder.Entity<Publisher>()
            .HasData(SeedData.Publishers());
    }

    public DbSet<VideoGame> VideoGames { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
}
