using Microsoft.EntityFrameworkCore;
using SSS.API.Models.Domain;
using System.Reflection.Metadata;
using Document = SSS.API.Models.Domain.Document;

namespace SSS.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<JobPosting> JobPostings{ get; set; }

        public DbSet<JobCategory> JobCategories { get; set; }

        public DbSet<BlogImage> BlogImages { get; set; }

        public DbSet<ImageFile> ImageFiles { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<LinkHandle> LinkHandles { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<JobSkill> JobSkills { get; set; }

        //public DbSet<EmployeeSupervisor> EmployeeSupervisors { get; set; }

        //public DbSet<EmployeeAssociate> EmployeeAssociates { get; set; }

    }
}
