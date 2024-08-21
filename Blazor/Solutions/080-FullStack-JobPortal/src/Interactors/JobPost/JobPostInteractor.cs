using DataAccess;
using ErrorOr;

namespace Interactors.JobPost;

public sealed class JobPostInteractor(JobPostRepository jobPostRepository)
{
    private readonly JobPostRepository _jobPostRepository = jobPostRepository;

    public async Task<List<Domain.Models.JobPost>> GetAllJobPostsAsync()
    {
        return await _jobPostRepository.GetAllJobPostsAsync() ?? [];
    }

    public async Task<ErrorOr<Domain.Models.JobPost>> GetJobPostByIdAsync(int id)
    {
        Domain.Models.JobPost? jobPost = await _jobPostRepository.GetJobPostByIdAsync(id);
        if (jobPost is null)
        {
            return Error.NotFound($"JobPost with id {id} does not exist.");
        }
        return jobPost;
    }

    public async Task<ErrorOr<bool>> CreateJobPostAsync(Domain.Models.JobPost jobPost)
    {
        try
        {
            await _jobPostRepository.CreateJobPostAsync(jobPost);
            return true;
        }
        catch (Exception e)
        {
            return Error.NotFound(e.Message);
        }
    }

    public async Task<ErrorOr<bool>> UpdateJobPostByIdAsync(Domain.Models.JobPost jobPost)
    {
        try
        {
            await _jobPostRepository.UpdateJobPostByIdAsync(jobPost);
            return true;
        }
        catch (Exception e)
        {
            return Error.NotFound(e.Message);
        }
    }

    public async Task<ErrorOr<bool>> DeleteJobPostByIdAsync(int id)
    {
        try
        {
            await _jobPostRepository.DeleteJobPostByIdAsync(id);
            return true;
        }
        catch (Exception e)
        {
            return Error.NotFound(e.Message);
        }
    }
}
