using Microsoft.EntityFrameworkCore;
using VotingSystem.Models;

namespace VotingSystem.Data;

public sealed class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Vote> Votes { get; set; }

    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vote>().HasData(GetVotes());
    }

    private static List<Vote> GetVotes()
    {
        return
        [
            new Vote { Id = 1, Voter = "Philip", VotedOn = "Bob", VotedOnParty = "Green" },
            new Vote { Id = 2, Voter = "Peter", VotedOn = "Charlie", VotedOnParty = "Red" },
            new Vote { Id = 3, Voter = "Sune", VotedOn = "Alice", VotedOnParty = "Blue" },
            new Vote { Id = 4, Voter = "Max", VotedOn = "Thomas", VotedOnParty = "Yellow" },
            new Vote { Id = 5, Voter = "Lucas", VotedOn = "Dutch", VotedOnParty = "Purple" }
        ];
    }
}
