using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Specifications
{
    public sealed class ProjectsWithTimeEntriesSpecification : Specification<Project>
    {
        public ProjectsWithTimeEntriesSpecification(string userId) 
            : base(p => !p.IsSoftDeleted && p.Users.Any(u => u.Id == userId))
        {
            AddInclude(te => te.ProjectDetails!);
            AddInclude(te => te.TimeEntries);
            AddOrderBy(p => p.Name);
        }
    }
}
