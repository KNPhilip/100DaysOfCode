namespace TimeTracker.Domain.Dtos.TimeEntry
{
    public record struct TimeEntryCreateDto(
        int ProjectId, 
        DateTime Start,
        DateTime? End
    );
}
