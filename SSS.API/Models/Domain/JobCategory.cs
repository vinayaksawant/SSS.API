namespace SSS.API.Models.Domain
{
    public class JobCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string UrlHandle { get; set; }

        public ICollection<JobPosting> JobPostings { get; set; }
    }
}
