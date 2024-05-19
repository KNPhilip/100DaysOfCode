using TimeTracker.Domain.Dtos.Project;

namespace TimeTracker.Domain.Dtos.TimeEntry
{
    public record struct TimeEntryResponseDto(
        int Id, 
        ProjectResponseDto Project, 
        DateTime Start, 
        DateTime? End
    );
}
