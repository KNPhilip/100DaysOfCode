using Microsoft.EntityFrameworkCore;
using TimeTracker.API.Data;
using TimeTracker.API.Services;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Exceptions;

namespace TimeTracker.API.Repositories
{
    public sealed class TimeEntryRepository(DataContext dbContext, 
        IUserService userService) : ITimeEntryRepository
    {
        public async Task<List<TimeEntry>> CreateTimeEntryAsync(TimeEntry timeEntry)
        {
            User user = await userService.GetUserAsync() 
                ?? throw new EntityNotFoundException("User not found.");

            timeEntry.User = user;

            dbContext.TimeEntries.Add(timeEntry);
            await dbContext.SaveChangesAsync();

            return await GetAllTimeEntriesAsync();
        }

        public async Task<List<TimeEntry>?> DeleteTimeEntryAsync(int id)
        {
            string? userId = userService.GetUserId();
            if (userId is null)
            {
                return null;
            }

            TimeEntry? dbTimeEntry = await dbContext.TimeEntries
                .FirstOrDefaultAsync(te => te.Id == id && te.User.Id == userId);
            if (dbTimeEntry is null)
            {
                return null;
            }
            dbContext.TimeEntries.Remove(dbTimeEntry);
            await dbContext.SaveChangesAsync();
            return await GetAllTimeEntriesAsync();
        }

        public async Task<List<TimeEntry>> GetAllTimeEntriesAsync()
        {
            string? userId = userService.GetUserId();

            if (userId is null)
            {
                return [];
            }

            return await dbContext.TimeEntries
                .Where(te => te.User.Id == userId)
                .Include(te => te.Project)
                .ToListAsync();
        }

        public async Task<List<TimeEntry>> GetTimeEntriesAsync(int skip, int take)
        {
            return await dbContext.TimeEntries
                .Include(te => te.Project)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<List<TimeEntry>> GetTimeEntriesByProjectIdAsync(int projectId)
        {
            string? userId = userService.GetUserId()
                ?? throw new EntityNotFoundException("User not found.");

            return await dbContext.TimeEntries
                .Include(te => te.Project)
                .Where(te => te.ProjectId == projectId && te.User.Id == userId)
                .ToListAsync();
        }

        public async Task<int> GetTimeEntriesCountAsync()
        {
            return await dbContext.TimeEntries.CountAsync();
        }

        public async Task<TimeEntry?> GetTimeEntryByIdAsync(int id)
        {
            string? userId = userService.GetUserId();
            if (userId is null)
            {
                return null;
            }

            return await dbContext.TimeEntries
                .Include(te => te.Project)
                .FirstOrDefaultAsync(te => te.Id == id && te.User.Id == userId);
        }

        public async Task<List<TimeEntry>> UpdateTimeEntryAsync(int id, TimeEntry timeEntry)
        {
            string userId = userService.GetUserId()
                ?? throw new EntityNotFoundException("User not found.");

            TimeEntry dbTimeEntry = await dbContext.TimeEntries
                .FirstOrDefaultAsync(te => te.Id == id && te.User.Id == userId)
                    ?? throw new EntityNotFoundException($"Entity with id {id} was not found.");

            dbTimeEntry.ProjectId = timeEntry.ProjectId;
            dbTimeEntry.Start = timeEntry.Start;
            dbTimeEntry.End = timeEntry.End;
            dbTimeEntry.DateLastUpdated = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return await GetAllTimeEntriesAsync();
        }
    }
}
