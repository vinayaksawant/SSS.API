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
    }
}
