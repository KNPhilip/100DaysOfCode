using Microsoft.EntityFrameworkCore;
using TimeTracker.API.Data;
using TimeTracker.API.Services;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Exceptions;
using TimeTracker.Domain.Specifications;

namespace TimeTracker.API.Repositories
{
    public sealed class TimeEntryRepository(DataContext dbContext, 
        IUserService userService) : ITimeEntryRepository
    {
        public async Task<List<TimeEntry>> CreateTimeEntryAsync(TimeEntry timeEntry)
        {
            timeEntry.User = await GetAndCheckUserAsync();

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

        public async Task<List<TimeEntry>> GetTimeEntriesByYearAsync(int year)
        {
            string userId = GetAndCheckUserId();

            return await dbContext.TimeEntries
                .Include(te => te.Project)
                .Where(te => te.Start.Year == year && te.User.Id == userId)
                .ToListAsync();
        }

        public async Task<List<TimeEntry>> GetTimeEntriesByMonthAsync(int year, int month)
        {
            string userId = GetAndCheckUserId();
            return await GetSpecificTimeEntries(new TimeEntriesByMonthSpecification(year, month, userId));
        }

        public async Task<List<TimeEntry>> GetTimeEntriesByDayAsync(int year, int month, int day)
        {
            string userId = GetAndCheckUserId();

            return await dbContext.TimeEntries
                .Include(te => te.Project)
                .Where(te => te.Start.Day == day 
                    && te.Start.Month == month 
                    && te.Start.Year == year 
                    && te.User.Id == userId)
                .ToListAsync();
        }

        public async Task<List<TimeEntry>> GetTimeEntriesByProjectIdAsync(int projectId)
        {
            string userId = GetAndCheckUserId();

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
            string userId = GetAndCheckUserId();

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

        public async Task<List<TimeEntry>> GetSpecificTimeEntries(Specification<TimeEntry> specification)
        {
            return await SpecificationQueryBuilder.GetQuery(dbContext.TimeEntries, specification)
                .Include(te => te.Project)
                .ToListAsync();
        }

        private string GetAndCheckUserId()
        {
            string? userId = userService.GetUserId()
                ?? throw new EntityNotFoundException("User not found.");

            return userId;
        }

        private async Task<User> GetAndCheckUserAsync()
        {
            User user = await userService.GetUserAsync()
                ?? throw new EntityNotFoundException("User not found.");

            return user;
        }
    }
}
