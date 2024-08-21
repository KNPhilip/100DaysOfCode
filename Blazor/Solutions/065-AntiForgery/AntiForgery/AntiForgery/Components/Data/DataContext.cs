using AntiForgery.Models;
using Microsoft.EntityFrameworkCore;

namespace AntiForgery.Components.Data;

public sealed class DataContext(DbContextOptions options) : DbContext(options)
{
    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>().HasData([
            new() { Id = 1, Date = new DateOnly(2022, 01, 08), TemperatureC = -13, Summary = "Freezing" },
            new() { Id = 2, Date = new DateOnly(2022, 01, 09), TemperatureC = -2, Summary = "Chilly" },
            new() { Id = 3, Date = new DateOnly(2022, 01, 10), TemperatureC = 1, Summary = "Freezing" },
            new() { Id = 4, Date = new DateOnly(2022, 01, 17), TemperatureC = -16, Summary = "Balmy" },
            new() { Id = 5, Date = new DateOnly(2022, 01, 19), TemperatureC = 14, Summary = "Bracing" },
            new() { Id = 6, Date = new DateOnly(2022, 01, 22), TemperatureC = -2, Summary = "Chilly" },
            new() { Id = 7, Date = new DateOnly(2022, 01, 24), TemperatureC = -13, Summary = "Freezing" },
            new() { Id = 8, Date = new DateOnly(2022, 01, 25), TemperatureC = 14, Summary = "Bracing" },
            new() { Id = 9, Date = new DateOnly(2022, 02, 06), TemperatureC = -16, Summary = "Balmy" },
            new() { Id = 10, Date = new DateOnly(2022, 02, 07), TemperatureC = -13, Summary = "Freezing" },
            new() { Id = 11, Date = new DateOnly(2022, 02, 09), TemperatureC = 1, Summary = "Freezing" },
            new() { Id = 12, Date = new DateOnly(2022, 02, 12), TemperatureC = 14, Summary = "Bracing" },
            new() { Id = 13, Date = new DateOnly(2022, 02, 16), TemperatureC = -2, Summary = "Chilly" },
            new() { Id = 14, Date = new DateOnly(2022, 02, 22), TemperatureC = -16, Summary = "Balmy" }
        ]);
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
}
