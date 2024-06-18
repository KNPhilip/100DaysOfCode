using ErrorOr;
using Interactors.JobPost;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1;

public sealed class JobPostV1Controller(JobPostInteractor jobPostInteractor) : V1ControllerTemplate
{
    private readonly JobPostInteractor _jobPostInteractor = jobPostInteractor;

    [HttpGet]
    public async Task<ActionResult<List<Domain.Models.JobPost>>> GetAllJobPostsAsync()
    {
        return await _jobPostInteractor.GetAllJobPostsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Domain.Models.JobPost>> GetJobPostByIdAsync(int id)
    {
        ErrorOr<Domain.Models.JobPost> jobPost = await _jobPostInteractor.GetJobPostByIdAsync(id);
        if (jobPost.IsError)
        {
            return NotFound(jobPost.Errors.FirstOrDefault());
        }
        return Ok(jobPost.Value);
    }

    [HttpPost]
    public async Task<ActionResult> CreateJobPostAsync(Domain.Models.JobPost jobPost)
    {
        ErrorOr<bool> result = await _jobPostInteractor.CreateJobPostAsync(jobPost);
        if (result.IsError)
        {
            return BadRequest(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateJobPostAsync(int id, Domain.Models.JobPost jobPost)
    {
        jobPost.Id = id;
        ErrorOr<bool> result = await _jobPostInteractor.UpdateJobPostByIdAsync(jobPost);
        if (result.IsError)
        {
            return BadRequest(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteJobPostAsync(int id)
    {
        ErrorOr<bool> result = await _jobPostInteractor.DeleteJobPostByIdAsync(id);
        if (result.IsError)
        {
            return NotFound(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }
}
