using SSS.API.Models.Domain;

namespace SSS.API.Repositories.Interface
{
    public interface IJobPostingRepository
    {
        Task<JobPosting> CreateAsync(JobPosting jobPosting);

        Task<IEnumerable<JobPosting>> GetAllAsync();

        Task<JobPosting?> GetByIdAsync(Guid id);
    }
}
