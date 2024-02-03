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
        [Authorize]
        public async Task<IActionResult> CreateJobPosting([FromBody] CreateJobPostingDto request)
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

        // GET: {apiBaseUrl}/api/JobPostings/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetJobPostById([FromRoute] Guid id)
        {
            // Get the JobPosting from Repo
            var blogPost = await jobPostingRepository.GetByIdAsync(id);

            if (blogPost is null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO
            var response = new JobPostingDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                JobCategories = blogPost.JobCategories.Select(x => new JobCategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }


        // GET: {apibaseurl}/api/JobPostings/{urlhandle}
        [HttpGet]
        [Route("{urlHandle}")]
        public async Task<IActionResult> GetJobPostingByUrlHandle([FromRoute] string urlHandle)
        {
            // Get blogpost details from repository
            var blogPost = await jobPostingRepository.GetByUrlHandleAsync(urlHandle);

            if (blogPost is null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO
            var response = new JobPostingDto
            {
                Id = blogPost.Id,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                JobCategories = blogPost.JobCategories.Select(x => new JobCategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle
                }).ToList()
            };

            return Ok(response);
        }

        // PUT: {apibaseurl}/api/JobPostings/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateBlogPostById([FromRoute] Guid id, UpdateJobPostingDto request)
        {
            // Convert DTO to Domain Model
            var jobPosting = new JobPosting
            {
                Id = id,
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

            // Foreach 
            foreach (var categoryGuid in request.JobCategories)
            {
                var existingCategory = await jobCategoryRepository.GetById(categoryGuid);

                if (existingCategory != null)
                {
                    jobPosting.JobCategories.Add(existingCategory);
                }
            }


            // Call Repository To Update BlogPost Domain Model
            var updatedJobPosting = await jobPostingRepository.UpdateAsync(jobPosting);

            if (updatedJobPosting == null)
            {
                return NotFound();
            }

            // Convert Domain model back to DTO
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

        // DELETE: {apibaseurl}/api/JobPostings/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteJobPosting([FromRoute] Guid id)
        {
            var deletedJobPosting = await jobPostingRepository.DeleteAsync(id);

            if (deletedJobPosting == null)
            {
                return NotFound();
            }

            // Convert Domain model to DTO
            var response = new JobPostingDto
            {
                Id = deletedJobPosting.Id,
                Author = deletedJobPosting.Author,
                Content = deletedJobPosting.Content,
                FeaturedImageUrl = deletedJobPosting.FeaturedImageUrl,
                IsVisible = deletedJobPosting.IsVisible,
                PublishedDate = deletedJobPosting.PublishedDate,
                ShortDescription = deletedJobPosting.ShortDescription,
                Title = deletedJobPosting.Title,
                UrlHandle = deletedJobPosting.UrlHandle
            };

            return Ok(response);
        }


    }
}
