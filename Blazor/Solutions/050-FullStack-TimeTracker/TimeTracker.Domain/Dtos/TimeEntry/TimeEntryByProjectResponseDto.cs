namespace TimeTracker.Domain.Dtos.TimeEntry
{
    public record struct TimeEntryByProjectResponseDto(
        int Id, 
        DateTime Start, 
        DateTime? End
    );
}
