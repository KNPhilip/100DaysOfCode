using Mapster;
using System.Net.Http.Json;
using TimeTracker.Domain.Dtos.TimeEntry;

namespace TimeTracker.UI.Services
{
    public sealed class TimeEntryService(HttpClient httpClient) : ITimeEntryService
    {
        public List<TimeEntryResponseDto> TimeEntries { get; set; } = [];
        public event Action? OnChange;

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

            if (result is not null)
            {
                TimeEntries = result;
                OnChange?.Invoke();
            }
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
    }
}
