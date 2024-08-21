using Mapster;
using TimeTracker.API.Repositories;
using TimeTracker.Domain.Dtos.TimeEntry;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Exceptions;

namespace TimeTracker.API.Services
{
    public sealed class TimeEntryService(ITimeEntryRepository timeEntryRepository) : ITimeEntryService
    {
        public async Task<List<TimeEntryResponseDto>> CreateTimeEntryAsync(TimeEntryCreateDto timeEntry)
        {
            TimeEntry newEntry = timeEntry.Adapt<TimeEntry>();
            List<TimeEntry> result = await timeEntryRepository.CreateTimeEntryAsync(newEntry);
            return result.Adapt<List<TimeEntryResponseDto>>();
        }

        public async Task<List<TimeEntryResponseDto>> GetAllTimeEntriesAsync()
        {
            List<TimeEntry> result = await timeEntryRepository.GetAllTimeEntriesAsync();
            return result.Adapt<List<TimeEntryResponseDto>>();
        }

        public async Task<List<TimeEntryResponseDto>?> UpdateTimeEntryAsync(int id, TimeEntryUpdateDto timeEntry)
        {
            try
            {
                TimeEntry updatedEntry = timeEntry.Adapt<TimeEntry>();
                List<TimeEntry>? result = await timeEntryRepository.UpdateTimeEntryAsync(id, updatedEntry);
                if (result is null)
                {
                    return null;
                }
                return result.Adapt<List<TimeEntryResponseDto>>();
            }
            catch(EntityNotFoundException)
            {
                return null;
            }
        }

        public async Task<List<TimeEntryResponseDto>?> DeleteTimeEntryAsync(int id)
        {
            List<TimeEntry>? result = await timeEntryRepository.DeleteTimeEntryAsync(id);
            if (result is null)
            {
                return null;
            }
            return result.Adapt<List<TimeEntryResponseDto>>();
        }

        public async Task<TimeEntryResponseDto?> GetTimeEntryByIdAsync(int id)
        {
            TimeEntry? result = await timeEntryRepository.GetTimeEntryByIdAsync(id);
            if (result is null)
            {
                return null;
            }
            return result?.Adapt<TimeEntryResponseDto>();
        }

        public async Task<List<TimeEntryResponseDto>> GetTimeEntriesByProjectIdAsync(int projectId)
        {
            List<TimeEntry> result = await timeEntryRepository.GetTimeEntriesByProjectIdAsync(projectId);
            return result.Adapt<List<TimeEntryResponseDto>>();
        }

        public async Task<TimeEntryResponseWrapperDto?> GetTimeEntriesAsync(int skip, int take)
        {
            List<TimeEntry> timeEntries = await timeEntryRepository.GetTimeEntriesAsync(skip, take);
            int timeEntriesCount = await timeEntryRepository.GetTimeEntriesCountAsync();
            return new TimeEntryResponseWrapperDto
            {
                TimeEntries = timeEntries.Adapt<List<TimeEntryResponseDto>>(),
                Count = timeEntriesCount
            };
        }
    }
}
