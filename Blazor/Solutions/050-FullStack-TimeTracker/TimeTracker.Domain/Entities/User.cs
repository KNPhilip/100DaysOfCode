using Microsoft.AspNetCore.Identity;

namespace TimeTracker.Domain.Entities
{
    public sealed class User : IdentityUser
    {
        public List<Project> Projects { get; set; } = [];
        public List<TimeEntry> TimeEntries { get; set; } = [];
    }
}
