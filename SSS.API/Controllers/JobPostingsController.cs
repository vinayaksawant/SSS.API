using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSS.API.Models.Domain;
using SSS.API.Models.DTO;
using SSS.API.Repositories.Implementaion;
using SSS.API.Repositories.Interface;

namespace SSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingsController : ControllerBase
    {
        private readonly IJobPostingRepository jobPostingRepository;
        private readonly IJobCategoryRepository jobCategoryRepository;

        public JobPostingsController(IJobPostingRepository jobPostingRepository, 
            IJobCategoryRepository jobCategoryRepository)
        {
            this.jobPostingRepository = jobPostingRepository;
            this.jobCategoryRepository = jobCategoryRepository;
        }

        // GET: {apibaseurl}/api/JobPostings
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllJobPostings()
        {
            var jobPostings = await jobPostingRepository.GetAllAsync();

            // Convert Domain model to DTO
            var response = new List<JobPostingDto>();
            foreach (var jobPosting in jobPostings)
            {
                response.Add(new JobPostingDto
                {
                    Id = jobPosting.Id,
                    Author = jobPosting.Author,
                    Content = jobPosting.Content,
                    FeaturedImageUrl = jobPosting.FeaturedImageUrl,
                    IsVisible = jobPosting.IsVisible,
                    PublishedDate = jobPosting.PublishedDate,
                    ShortDescription = jobPosting.ShortDescription,
                    Title = jobPosting.Title,
                    UrlHandle = jobPosting.UrlHandle,
                    JobCategories = jobPosting.JobCategories.Select(x => new JobCategoryDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UrlHandle = x.UrlHandle
                    }).ToList()
                });
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobPosting(CreateJobPostingDto request)
        {

            // Convert DTO to DOmain
            var jobPosting = new JobPosting
            {
                Author = request.Author,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                IsVisible = request.IsVisible,
                PublishedDate = request.PublishedDate,
                ShortDescription = request.ShortDescription,
                Title = request.Title,
                UrlHandle = request.UrlHandle,
                JobCategories = new List<JobCategory>()
            };

            foreach (var jobcategoryguid in request.JobCategories)
            {
                var existingCategory = await jobCategoryRepository.GetById(jobcategoryguid);
                if (existingCategory is not null)
                {
                    jobPosting.JobCategories.Add(existingCategory);
                }
            }

            jobPosting = await jobPostingRepository.CreateAsync(jobPosting);

            // Convert Domain Model back to DTO
            var response = new JobPostingDto
            {
                Id = jobPosting.Id,
                Author = jobPosting.Author,
                Content = jobPosting.Content,
                FeaturedImageUrl = jobPosting.FeaturedImageUrl,
                IsVisible = jobPosting.IsVisible,
                PublishedDate = jobPosting.PublishedDate,
                ShortDescription = jobPosting.ShortDescription,
                Title = jobPosting.Title,
                UrlHandle = jobPosting.UrlHandle,
                JobCategories = jobPosting.JobCategories.Select(x => new JobCategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }




    }
}
