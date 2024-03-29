﻿using SSS.API.Models.DTO;

namespace SSS.API.Models.Domain
{
    public class JobPosting
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

        public ICollection<JobCategory> JobCategories { get; set; }

        public ICollection<JobSkill> RequiredJobSkills { get; set; }

        public ICollection<JobSkill> GoodToHaveJobSkills { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<LinkHandle> LinkHandles { get; set; }
    }
}
