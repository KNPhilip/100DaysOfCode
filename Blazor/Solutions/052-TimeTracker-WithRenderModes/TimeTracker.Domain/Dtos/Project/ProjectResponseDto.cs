using TimeTracker.Domain.Dtos.TimeEntry;

namespace TimeTracker.Domain.Dtos.Project
{
    public record struct ProjectResponseDto(
        int Id,
        string Name,
        string? Description,
        List<TimeEntryByProjectResponseDto> TimeEntries,
        DateTime? StartDate,
        DateTime? EndDate
    );
}
