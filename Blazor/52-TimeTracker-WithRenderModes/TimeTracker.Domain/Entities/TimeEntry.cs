namespace TimeTracker.Domain.Entities
{
    public sealed class TimeEntry : DbEntity
    {
        private int? projectId;
        private DateTime? end;

        public int? ProjectId 
        { 
            get => projectId; 
            set
            {
                if (value is not null)
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "Project id must be greater than 0");
                    }
                }

                projectId = value;
            } 
        }

        public Project? Project { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime? End 
        { 
            get => end; 
            set
            {
                if (value is not null)
                {
                    if (value < Start)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), "End date must be after the start date");
                    }
                }

                end = value;
            }
        }

        public required User User { get; set; }
    }
}
