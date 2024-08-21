using TimeTracker.Domain.Dtos.TimeEntry;
using TimeTracker.Domain.Entities;

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
        Task<List<TimeEntryResponseDto>> GetTimeEntriesByYearAsync(int year);
        Task<List<TimeEntryResponseDto>> GetTimeEntriesByMonthAsync(int month, int year);
        Task<List<TimeEntryResponseDto>> GetTimeEntriesByDayAsync(int year, int month, int day);
    }
}
