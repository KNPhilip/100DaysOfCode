namespace TimeTracker.Domain.Entities
{
    public sealed class Project : DbEntity
    {
        private string? name;

        public required string Name 
        { 
            get => name!; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty", nameof(value));
                }

                name = value;
            }
        }

        public List<TimeEntry> TimeEntries { get; set; } = [];
        public ProjectDetails? ProjectDetails { get; set; }
        public List<User> Users { get; set; } = [];
    }
}
