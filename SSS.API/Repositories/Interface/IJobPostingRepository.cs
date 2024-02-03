using SSS.API.Models.Domain;

namespace SSS.API.Repositories.Interface
{
    public interface IJobPostingRepository
    {
        Task<JobPosting> CreateAsync(JobPosting jobPosting);

        Task<IEnumerable<JobPosting>> GetAllAsync();

        Task<JobPosting?> GetByIdAsync(Guid id);

        Task<JobPosting?> GetByUrlHandleAsync(string urlHandle);

        Task<JobPosting?> UpdateAsync(JobPosting blogPost);

        Task<JobPosting?> DeleteAsync(Guid id);
    }
}
