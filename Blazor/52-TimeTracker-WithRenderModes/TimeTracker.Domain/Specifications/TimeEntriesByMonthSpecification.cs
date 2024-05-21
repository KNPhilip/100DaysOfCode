using TimeTracker.Domain.Entities;

namespace TimeTracker.Domain.Specifications
{
    public sealed class TimeEntriesByMonthSpecification(int year, int month, string userId) 
        : Specification<TimeEntry>(te => te.Start.Month == month
            && te.Start.Year == year && te.User.Id == userId) { }
}
