using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSS.API.Data;
using SSS.API.Models.Domain;
using SSS.API.Models.DTO;
using SSS.API.Repositories.Interface;

namespace SSS.API.Controllers
{
    // http://localhost:XXXX/api/JobCategories
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoriesController : ControllerBase
    {
        private readonly IJobCategoryRepository jobCategoryRepository;

        public JobCategoriesController(IJobCategoryRepository jobCategoryRepository)
        {
            this.jobCategoryRepository = jobCategoryRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateJobCategory(CreateJobCategoryDto request) 
        {
            //map DTO to Domain Model
            var jobcategory = new JobCategory
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await jobCategoryRepository.CreateAsync(jobcategory);

            //map Domain Model to DTO
            var response = new JobCategoryDto
            {
                Id = jobcategory.Id,
                Name = jobcategory.Name,
                UrlHandle = jobcategory.UrlHandle,
            };

            return Ok(response);    
        
        }

        // GET: https://localhost:7226/api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var caterogies = await jobCategoryRepository.GetAllAsync();

            // Map Domain model to DTO

            var response = new List<JobCategoryDto>();
            foreach (var category in caterogies)
            {
                response.Add(new JobCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            return Ok(response);
        }

        // GET: https://localhost:7226/api/categories/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var existingCategory = await jobCategoryRepository.GetById(id);

            if (existingCategory is null)
            {
                return NotFound();
            }

            var response = new JobCategoryDto
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle
            };

            return Ok(response);
        }

        // PUT: https://localhost:7226/api/categories/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateJobCategoryDto request)
        {
            // Convert DTO to Domain Model
            var category = new JobCategory
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            category = await jobCategoryRepository.UpdateAsync(category);

            if (category == null)
            {
                return NotFound();
            }

            // Convert Domain model to DTO
            var response = new JobCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }


        // DELETE: https://localhost:7226/api/categories/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await jobCategoryRepository.DeleteAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            // Convert Domain model to DTO
            var response = new JobCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

    }
}
