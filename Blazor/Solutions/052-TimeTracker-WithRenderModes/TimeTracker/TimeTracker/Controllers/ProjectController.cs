using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Server.Services;
using TimeTracker.Domain.Dtos.Project;

namespace TimeTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public sealed class ProjectController(IProjectService projectService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProjectResponseDto>>> GetAllProjects()
        {
            return Ok(await projectService.GetAllProjectsAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectResponseDto>> GetProjectById(int id)
        {
            ProjectResponseDto? result = await projectService
                .GetProjectByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectResponseDto>>> CreateProject(ProjectCreateDto project)
        {
            return Ok(await projectService
                .CreateProjectAsync(project));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProjectResponseDto>>> UpdateProject(int id, ProjectUpdateDto project)
        {
            List<ProjectResponseDto>? result = await projectService
                .UpdateProjectAsync(id, project);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectResponseDto>>> DeleteProject(int id)
        {
            List<ProjectResponseDto>? result = await projectService.DeleteProjectAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
