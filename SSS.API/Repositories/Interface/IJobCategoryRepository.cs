using SSS.API.Models.Domain;

namespace SSS.API.Repositories.Interface
{
    public interface IJobCategoryRepository
    {
        Task<JobCategory> CreateAsync(JobCategory jobCategory);

        Task<IEnumerable<JobCategory>> GetAllAsync();

        Task<JobCategory?> GetById(Guid id);

        Task<JobCategory?> UpdateAsync(JobCategory jobCategory);

        Task<JobCategory?> DeleteAsync(Guid id);
    }
}
