using Mapster;
using System.Net.Http.Json;
using TimeTracker.Domain.Dtos.Project;

namespace TimeTracker.Client.Services
{
    public sealed class ProjectService(HttpClient httpClient) : IProjectService
    {
        public List<ProjectResponseDto> Projects { get; set; } = [];

        public event Action? OnChange;

        public async Task CreateProject(ProjectRequestDto project)
        {
            await httpClient.PostAsJsonAsync("api/project/", project.Adapt<ProjectCreateDto>());
        }

        public async Task DeleteProject(int id)
        {
            await httpClient.DeleteAsync($"api/project/{id}");
        }

        public async Task<ProjectResponseDto> GetProjectById(int id)
        {
            return await httpClient.GetFromJsonAsync<ProjectResponseDto>($"api/project/{id}");
        }

        public async Task LoadAllProjectsAsync()
        {
            var result = await httpClient.GetFromJsonAsync<List<ProjectResponseDto>>("api/project");
            if (result is not null)
            {
                Projects = result;
                OnChange?.Invoke();
            }
        }

        public async Task UpdateProject(int id, ProjectRequestDto project)
        {
            await httpClient.PutAsJsonAsync($"api/project/{id}", project.Adapt<ProjectUpdateDto>());
        }
    }
}
