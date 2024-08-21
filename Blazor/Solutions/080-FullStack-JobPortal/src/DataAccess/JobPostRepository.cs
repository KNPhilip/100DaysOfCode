using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Domain.Models;

namespace DataAccess;

public class JobPostRepository(DataContext context)
{
    private readonly DataContext _context = context;

    public virtual async Task<List<JobPost>> GetAllJobPostsAsync()
    {
        return await _context.JobPosts.Include(c => c.Company)
            .Include(hm => hm.HiringManager).ToListAsync() ?? [];
    }

    public virtual async Task<JobPost?> GetJobPostByIdAsync(int id)
    {
        return await _context.JobPosts.Include(c => c.Company)
            .Include(hm => hm.HiringManager).FirstOrDefaultAsync(jp => jp.Id == id);
    }

    public virtual async Task CreateJobPostAsync(JobPost jobPost)
    {
        await _context.JobPosts.AddAsync(jobPost.Adapt<JobPost>());
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateJobPostByIdAsync(JobPost newJobPost)
    {
        JobPost? jobPost = await _context.JobPosts.FindAsync(newJobPost.Id)
            ?? throw new Exception($"JobPost with id {newJobPost.Id} does not exist.");

        jobPost = newJobPost.Adapt(jobPost);

        _context.JobPosts.Update(jobPost);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteJobPostByIdAsync(int id)
    {
        JobPost? jobPost = await _context.JobPosts.FindAsync(id)
            ?? throw new Exception($"JobPost with id {id} does not exist.");

        _context.JobPosts.Remove(jobPost);
        await _context.SaveChangesAsync();
    }
}
