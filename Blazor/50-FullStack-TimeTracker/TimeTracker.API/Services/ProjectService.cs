using Mapster;
using TimeTracker.API.Repositories;
using TimeTracker.Domain.Dtos.Project;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Exceptions;

namespace TimeTracker.API.Services
{
    public sealed class ProjectService(IProjectRepository projectRepository) : IProjectService
    {
        public async Task<List<ProjectResponseDto>> CreateProjectAsync(ProjectCreateDto project)
        {
            Project newProject = project.Adapt<Project>();
            newProject.ProjectDetails = project.Adapt<ProjectDetails>();
            List<Project> result = await projectRepository.CreateProjectAsync(newProject);
            return result.Adapt<List<ProjectResponseDto>>();
        }

        public async Task<List<ProjectResponseDto>> GetAllProjectsAsync()
        {
            List<Project> result = await projectRepository.GetAllProjectsAsync();
            return result.Adapt<List<ProjectResponseDto>>();
        }

        public async Task<List<ProjectResponseDto>?> UpdateProjectAsync(int id, ProjectUpdateDto project)
        {
            try
            {
                Project updatedProject = project.Adapt<Project>();
                updatedProject.ProjectDetails = project.Adapt<ProjectDetails>();
                List<Project>? result = await projectRepository.UpdateProjectAsync(id, updatedProject);
                if (result is null)
                {
                    return null;
                }
                return result.Adapt<List<ProjectResponseDto>>();
            }
            catch (EntityNotFoundException)
            {
                return null;
            }
        }

        public async Task<List<ProjectResponseDto>?> DeleteProjectAsync(int id)
        {
            List<Project>? result = await projectRepository.DeleteProjectAsync(id);
            if (result is null)
            {
                return null;
            }
            return result.Adapt<List<ProjectResponseDto>>();
        }

        public async Task<ProjectResponseDto?> GetProjectByIdAsync(int id)
        {
            Project? result = await projectRepository.GetProjectByIdAsync(id);
            if (result is null)
            {
                return null;
            }
            return result?.Adapt<ProjectResponseDto>();
        }
    }
}
