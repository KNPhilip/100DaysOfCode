using TimeTracker.Domain.Dtos.TimeEntry;

namespace TimeTracker.API.Services
{
    public interface ITimeEntryService
    {
        Task<TimeEntryResponseDto?> GetTimeEntryByIdAsync(int id);
        Task<List<TimeEntryResponseDto>> GetAllTimeEntriesAsync();
        Task<TimeEntryResponseWrapperDto?> GetTimeEntriesAsync(int skip, int take);
        Task<List<TimeEntryResponseDto>> GetTimeEntriesByProjectIdAsync(int projectId);
        Task<List<TimeEntryResponseDto>> CreateTimeEntryAsync(TimeEntryCreateDto timeEntry);
        Task<List<TimeEntryResponseDto>?> UpdateTimeEntryAsync(int id, TimeEntryUpdateDto timeEntry);
        Task<List<TimeEntryResponseDto>?> DeleteTimeEntryAsync(int id);
    }
}
