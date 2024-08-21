using TimeTracker.Domain.Dtos.Project;

namespace TimeTracker.Client.Services
{
    public interface IProjectService
    {
        event Action? OnChange;
        public List<ProjectResponseDto> Projects { get; set; }
        Task LoadAllProjectsAsync();
        Task<ProjectResponseDto> GetProjectById(int id);
        Task CreateProject(ProjectRequestDto project);
        Task UpdateProject(int id, ProjectRequestDto project);
        Task DeleteProject(int id);
    }
}
