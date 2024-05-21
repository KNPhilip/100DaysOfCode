using TimeTracker.Domain.Entities;

namespace TimeTracker.Server.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<List<Project>> CreateProjectAsync(Project timeEntry);
        Task<List<Project>> UpdateProjectAsync(int id, Project timeEntry);
        Task<List<Project>?> DeleteProjectAsync(int id);

    }
}
