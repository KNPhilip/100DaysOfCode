namespace TimeTracker.Domain.Dtos.TimeEntry
{
    public record struct TimeEntryResponseWrapperDto(
        List<TimeEntryResponseDto> TimeEntries,
        int Count
    );
}
