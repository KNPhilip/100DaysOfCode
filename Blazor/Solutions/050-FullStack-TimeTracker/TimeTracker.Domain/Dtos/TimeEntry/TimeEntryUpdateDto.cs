namespace TimeTracker.Domain.Dtos.TimeEntry
{
    public record struct TimeEntryUpdateDto(
        int ProjectId, 
        DateTime Start,
        DateTime? End
    );
}
