using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public sealed class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }
}
