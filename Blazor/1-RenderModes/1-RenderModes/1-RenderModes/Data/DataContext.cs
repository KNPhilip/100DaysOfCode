namespace _1_RenderModes.Data;

public sealed class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
}
