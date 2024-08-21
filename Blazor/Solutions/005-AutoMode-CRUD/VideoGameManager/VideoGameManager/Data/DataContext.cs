namespace VideoGameManager.Data;

public sealed class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<VideoGame> VideoGames { get; set; }
}
