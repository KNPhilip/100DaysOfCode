using TimeTracker.Domain.Entities;

namespace TimeTracker.Server.Repositories
{
    public interface ITimeEntryRepository
    {
        Task<List<TimeEntry>> GetAllTimeEntriesAsync();
        Task<List<TimeEntry>> GetTimeEntriesAsync(int skip, int take);
        Task<int> GetTimeEntriesCountAsync();
        Task<TimeEntry?> GetTimeEntryByIdAsync(int id);
        Task<List<TimeEntry>> GetTimeEntriesByProjectIdAsync(int projectId);
        Task<List<TimeEntry>> GetTimeEntriesByYearAsync(int year);
        Task<List<TimeEntry>> GetTimeEntriesByMonthAsync(int year, int month);
        Task<List<TimeEntry>> GetTimeEntriesByDayAsync(int year, int month, int day);
        Task<List<TimeEntry>> CreateTimeEntryAsync(TimeEntry timeEntry);
        Task<List<TimeEntry>> UpdateTimeEntryAsync(int id, TimeEntry timeEntry);
        Task<List<TimeEntry>?> DeleteTimeEntryAsync(int id);
    }
}
