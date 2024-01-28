using Microsoft.EntityFrameworkCore;
using SSS.API.Models.Domain;

namespace SSS.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<JobPosting> JobPostings{ get; set; }

        public DbSet<JobCategory> JobCategories { get; set; }
    }
}
