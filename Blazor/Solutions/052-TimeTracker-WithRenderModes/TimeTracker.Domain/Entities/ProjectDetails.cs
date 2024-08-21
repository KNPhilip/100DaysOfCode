namespace TimeTracker.Domain.Entities
{
    public sealed class ProjectDetails
    {
        private int id;
        private string? description;
        private DateTime? endDate;
        private int projectId;

        public int Id 
        { 
            get => id; 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The Id must be larger than 0");
                }

                id = value;
            }
        }

        public string? Description 
        { 
            get => description; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The Description cannot be null or empty", nameof(value));
                }

                description = value;
            }
        }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate 
        { 
            get => endDate; 
            set
            {
                if (endDate < StartDate)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The end date must be after the start date");
                }

                endDate = value;
            }
        }

        public int ProjectId 
        { 
            get => projectId; 
            set
            {
                if (projectId <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The ProjectId must be larger than 0");
                }

                projectId = value;
            }
        }

        public required Project Project { get; set; }
    }
}
