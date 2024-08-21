namespace VotingSystem.Models;

public sealed class Vote
{
    public int Id { get; set; }
    public string? Voter { get; set; }
    public string? VotedOn { get; set; }
    public string? VotedOnParty { get; set; }
}
