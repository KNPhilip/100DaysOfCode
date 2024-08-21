using Mapster;
using System.Net.Http.Json;
using TimeTracker.Domain.Dtos.TimeEntry;

namespace TimeTracker.UI.Services
{
    public sealed class TimeEntryService(HttpClient httpClient) : ITimeEntryService
    {
        public List<TimeEntryResponseDto> TimeEntries { get; set; } = [];

        public event Action? OnChange;
        public TimeSpan TotalDuration { get; set; }

        public async Task CreateTimeEntryAsync(TimeEntryRequestDto timeEntry)
        {
            await httpClient.PostAsJsonAsync("api/timeentry/", timeEntry.Adapt<TimeEntryRequestDto>());
        }

        public async Task DeleteTimeEntryAsync(int id)
        {
            await httpClient.DeleteAsync($"api/timeentry/{id}");
        }

        public async Task<TimeEntryResponseWrapperDto> GetTimeEntriesAsync(int skip, int take)
        {
            return await httpClient
                .GetFromJsonAsync<TimeEntryResponseWrapperDto>($"api/timeentry/{skip}/{take}");
        }

        public async Task GetTimeEntriesByProjectAsync(int projectId)
        {
            List<TimeEntryResponseDto>? result = null;
            if (projectId <= 0)
            {
                result = await httpClient.GetFromJsonAsync<List<TimeEntryResponseDto>>("api/timeentry");
            }
            else
            {
                result = await httpClient
                    .GetFromJsonAsync<List<TimeEntryResponseDto>>($"api/timeentry/project/{projectId}");
            }

            SetTimeEntries(result);
        }

        public async Task<TimeEntryResponseDto> GetTimeEntryByIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<TimeEntryResponseDto>($"api/timeentry/{id}");
        }

        public async Task UpdateTimeEntryAsync(int id, TimeEntryRequestDto timeEntry)
        {
            await httpClient
                .PutAsJsonAsync($"api/timeentry/{id}", timeEntry.Adapt<TimeEntryRequestDto>());
        }

        public async Task GetTimeEntriesByYearAsync(int year)
        {
            List<TimeEntryResponseDto>? result = await httpClient
                .GetFromJsonAsync<List<TimeEntryResponseDto>>($"api/timeentry/year/{year}");

            SetTimeEntries(result);
        }

        public async Task GetTimeEntriesByMonthAsync(int year, int month)
        {
            List<TimeEntryResponseDto>? result = await httpClient
                .GetFromJsonAsync<List<TimeEntryResponseDto>>($"api/timeentry/year/{year}/month/{month}");

            SetTimeEntries(result);
        }

        public async Task GetTimeEntriesByDayAsync(int year, int month, int day)
        {
            List<TimeEntryResponseDto>? result = await httpClient
                .GetFromJsonAsync<List<TimeEntryResponseDto>>($"api/timeentry/year/{year}/month/{month}/day/{day}");

            SetTimeEntries(result);
        }

        private void SetTimeEntries(List<TimeEntryResponseDto>? result)
        {
            if (result is not null)
            {
                TimeEntries = result;
                CalculateTotalDuration();
                OnChange?.Invoke();
            }
        }

        private TimeSpan CalculateDuration(TimeEntryResponseDto timeEntry)
        {
            if (timeEntry.End is null || timeEntry.End.Value < timeEntry.Start)
            {
                return new TimeSpan();
            }

            TimeSpan duration = timeEntry.End.Value - timeEntry.Start;

            return duration;
        }

        private void CalculateTotalDuration()
        {
            TotalDuration = new TimeSpan();
            foreach (TimeEntryResponseDto timeEntry in TimeEntries)
            {
                TotalDuration += CalculateDuration(timeEntry);
            }
        }
    }
}
