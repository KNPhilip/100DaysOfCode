using TimeTracker.Domain.Dtos.TimeEntry;

namespace TimeTracker.UI.Services
{
    public interface ITimeEntryService
    {
        event Action? OnChange;
        public List<TimeEntryResponseDto> TimeEntries { get; set; }

        Task GetTimeEntriesByProjectAsync(int projectId);
        Task<TimeEntryResponseWrapperDto> GetTimeEntriesAsync(int skip, int take);
        Task<TimeEntryResponseDto> GetTimeEntryByIdAsync(int id);
        Task CreateTimeEntryAsync(TimeEntryRequestDto timeEntry);
        Task UpdateTimeEntryAsync(int id, TimeEntryRequestDto timeEntry);
        Task DeleteTimeEntryAsync(int id);
    }
}
