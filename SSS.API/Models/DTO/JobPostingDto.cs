using SSS.API.Models.Domain;

namespace SSS.API.Models.DTO
{
    public class JobPostingDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }

        public string FeaturedImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        public ICollection<JobCategoryDto> JobCategories { get; set; } = new List<JobCategoryDto>();
    }
}
