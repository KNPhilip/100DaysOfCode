namespace GoogleAuth.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : IdentityDbContext<ApplicationUser>(options)
{
}
