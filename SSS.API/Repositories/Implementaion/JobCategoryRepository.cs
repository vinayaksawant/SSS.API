﻿using Microsoft.EntityFrameworkCore;
using SSS.API.Data;
using SSS.API.Models.Domain;
using SSS.API.Repositories.Interface;

namespace SSS.API.Repositories.Implementaion
{
    public class JobCategoryRepository : IJobCategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public JobCategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<JobCategory> CreateAsync(JobCategory jobCategory)
        {
            await dbContext.JobCategories.AddAsync(jobCategory);
            await dbContext.SaveChangesAsync();

            return jobCategory;
        }


        public async Task<IEnumerable<JobCategory>> GetAllAsync()
        {
            return await dbContext.JobCategories.ToListAsync();
        }

        public async Task<JobCategory?> GetById(Guid id)
        {
            return await dbContext.JobCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
