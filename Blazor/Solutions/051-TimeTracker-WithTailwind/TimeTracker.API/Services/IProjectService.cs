using TimeTracker.Domain.Dtos.Project;

namespace TimeTracker.API.Services
{
    public interface IProjectService
    {
        Task<ProjectResponseDto?> GetProjectByIdAsync(int id);
        Task<List<ProjectResponseDto>> GetAllProjectsAsync();
        Task<List<ProjectResponseDto>> CreateProjectAsync(ProjectCreateDto timeEntry);
        Task<List<ProjectResponseDto>?> UpdateProjectAsync(int id, ProjectUpdateDto timeEntry);
        Task<List<ProjectResponseDto>?> DeleteProjectAsync(int id);
    }
}
