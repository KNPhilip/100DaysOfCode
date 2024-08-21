using TimeTracker.Domain.Dtos.TimeEntry;

namespace TimeTracker.Client.Services
{
    public interface ITimeEntryService
    {
        event Action? OnChange;
        public List<TimeEntryResponseDto> TimeEntries { get; set; }
        public TimeSpan TotalDuration { get; set; }

        Task GetTimeEntriesByProjectAsync(int projectId);
        Task<TimeEntryResponseWrapperDto> GetTimeEntriesAsync(int skip, int take);
        Task<TimeEntryResponseDto> GetTimeEntryByIdAsync(int id);
        Task CreateTimeEntryAsync(TimeEntryRequestDto timeEntry);
        Task UpdateTimeEntryAsync(int id, TimeEntryRequestDto timeEntry);
        Task DeleteTimeEntryAsync(int id);
        Task GetTimeEntriesByYearAsync(int year);
        Task GetTimeEntriesByMonthAsync(int year, int month);
        Task GetTimeEntriesByDayAsync(int year, int month, int day);
    }
}
