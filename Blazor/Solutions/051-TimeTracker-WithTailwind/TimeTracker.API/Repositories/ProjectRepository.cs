using Microsoft.EntityFrameworkCore;
using TimeTracker.API.Data;
using TimeTracker.API.Services;
using TimeTracker.Domain.Entities;
using TimeTracker.Domain.Exceptions;
using TimeTracker.Domain.Specifications;

namespace TimeTracker.API.Repositories
{
    public sealed class ProjectRepository(DataContext dbContext,
        IUserService userService) : IProjectRepository
    {
        public async Task<List<Project>> CreateProjectAsync(Project project)
        {
            User user = await userService.GetUserAsync()
                ?? throw new EntityNotFoundException("User not found.");

            project.Users.Add(user);

            dbContext.Projects.Add(project);
            await dbContext.SaveChangesAsync();

            return await GetAllProjectsAsync();
        }

        public async Task<List<Project>?> DeleteProjectAsync(int id)
        {
            string? userId = userService.GetUserId();

            if (userId is null)
            {
                return null;
            }

            Project? dbProject = await dbContext.Projects
                .FirstOrDefaultAsync(p => !p.IsSoftDeleted && p.Id == id
                    && p.Users.Any(u => u.Id == userId));
            if (dbProject is null)
            {
                return null;
            }

            dbProject.IsSoftDeleted = true;
            dbProject.DateSoftDeleted = DateTime.Now;

            await dbContext.SaveChangesAsync();
            return await GetAllProjectsAsync();
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            string? userId = userService.GetUserId();

            if (userId is null)
            {
                return [];
            }

            return await GetSpecificProjectsAsync(new ProjectsWithTimeEntriesSpecification(userId));
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            string? userId = userService.GetUserId();

            if (userId is null)
            {
                return null;
            }

            return await dbContext.Projects
                .Include(p => p.ProjectDetails)
                .FirstOrDefaultAsync(p => !p.IsSoftDeleted && p.Id == id 
                    && p.Users.Any(u => u.Id == userId));
        }

        public async Task<List<Project>> UpdateProjectAsync(int id, Project project)
        {
            string userId = userService.GetUserId()
                ?? throw new EntityNotFoundException("User not found.");

            Project dbProject = await dbContext.Projects
                .FirstOrDefaultAsync(p => !p.IsSoftDeleted && p.Id == id
                    && p.Users.Any(u => u.Id == userId))
                        ?? throw new EntityNotFoundException($"Project with id {id} was not found.");

            dbProject.Name = project.Name;
            dbProject.DateLastUpdated = DateTime.Now;

            if (project.ProjectDetails is not null && dbProject.ProjectDetails is not null)
            {
                dbProject.ProjectDetails!.Description = project.ProjectDetails!.Description;
                dbProject.ProjectDetails.StartDate = project.ProjectDetails.StartDate;
                dbProject.ProjectDetails.EndDate = project.ProjectDetails.EndDate;
            }
            else if (project.ProjectDetails is not null && dbProject.ProjectDetails is null)
            {
                dbProject.ProjectDetails = new ProjectDetails
                {
                    Description = project.ProjectDetails!.Description,
                    StartDate = project.ProjectDetails.StartDate,
                    EndDate = project.ProjectDetails.EndDate,
                    Project = project
                };
            }

            await dbContext.SaveChangesAsync();

            return await GetAllProjectsAsync();
        }

        public async Task<List<Project>> GetSpecificProjectsAsync(Specification<Project> specification) =>
            await SpecificationQueryBuilder.GetQuery(dbContext.Projects, specification).ToListAsync();
    }
}
