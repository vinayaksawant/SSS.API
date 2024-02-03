using Microsoft.EntityFrameworkCore;
using SSS.API.Data;
using SSS.API.Models.Domain;
using SSS.API.Repositories.Interface;

namespace SSS.API.Repositories.Implementaion
{
    public class JobPostingRepository : IJobPostingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public JobPostingRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<JobPosting> CreateAsync(JobPosting jobPosting)
        {
            await dbContext.JobPostings.AddAsync(jobPosting);
            await dbContext.SaveChangesAsync();

            return jobPosting;
        }


        public async Task<IEnumerable<JobPosting>> GetAllAsync()
        {
            return await dbContext.JobPostings.Include(x => x.JobCategories).ToListAsync();
        }

        public async Task<JobPosting?> GetByIdAsync(Guid id)
        {
            return await dbContext.JobPostings.Include(x => x.JobCategories).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<JobPosting?> DeleteAsync(Guid id)
        {
            var existingJobPost = await dbContext.JobPostings.FirstOrDefaultAsync(x => x.Id == id);

            if (existingJobPost != null)
            {
                dbContext.JobPostings.Remove(existingJobPost);
                await dbContext.SaveChangesAsync();
                return existingJobPost;
            }

            return null;
        }


        public async Task<JobPosting?> UpdateAsync(JobPosting jobPosting)
        {
            var existingJobPost = await dbContext.JobPostings.Include(x => x.JobCategories)
                .FirstOrDefaultAsync(x => x.Id == jobPosting.Id);

            if (existingJobPost == null)
            {
                return null;
            }

            // Update BlogPost
            dbContext.Entry(existingJobPost).CurrentValues.SetValues(jobPosting);

            // Update Categories
            existingJobPost.JobCategories = jobPosting.JobCategories;

            await dbContext.SaveChangesAsync();

            return jobPosting;
        }

        public async Task<JobPosting?> GetByUrlHandleAsync(string urlHandle)
        {
            return await dbContext.JobPostings.Include(x => x.JobCategories).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }
    }
}
