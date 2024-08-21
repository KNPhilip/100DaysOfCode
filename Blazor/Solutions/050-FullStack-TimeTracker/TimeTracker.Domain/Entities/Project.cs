namespace TimeTracker.Domain.Entities
{
    public sealed class Project : DbEntity
    {
        public required string Name { get; set; }
        public List<TimeEntry> TimeEntries { get; set; } = [];
        public ProjectDetails? ProjectDetails { get; set; }
        public List<User> Users { get; set; } = [];
    }
}
