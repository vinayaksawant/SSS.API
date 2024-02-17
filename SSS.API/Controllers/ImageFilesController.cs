using SSS.API.Models.Domain;
using SSS.API.Models.DTO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using SSS.API.Repositories.Interface;

namespace SSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageFilesController : ControllerBase
    {

        private readonly IImageFileRepository imageFileRepository;

        public ImageFilesController(IImageFileRepository imageFileRepository)
        {
            this.imageFileRepository = imageFileRepository;
        }

        // GET: {apibaseURL}/api/Images
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            // call image repository to get all images
            var images = await imageFileRepository.GetAll();

            // Convert Domain model to DTO
            var response = new List<BlogImageDto>();
            foreach (var image in images)
            {
                response.Add(new BlogImageDto
                {
                    Id = image.Id,
                    Title = image.ImageFileTitle,
                    DateCreated = image.DateCreated,
                    FileExtension = image.ImageFileExtension,
                    FileName = image.ImageFileName,
                    Url = image.ImageFileUrl
                });
            }

            return Ok(response);
        }


        // POST: {apibaseurl}/api/images
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file,
            [FromForm] string fileName, [FromForm] string title , [FromForm]  string fileType)
        {
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
                // File upload
                var imageFile = new ImageFile
                {
                    ImageFileExtension = Path.GetExtension(file.FileName).ToLower(),
                    ImageFileName = fileName,
                    ImageFileTitle = title,
                    ImageFileType = fileType,
                    DateCreated = DateTime.Now
                };

                imageFile = await imageFileRepository.Upload(file, imageFile);

                // Convert Domain Model to DTO
                //var response = new BlogImageDto
                //{
                //    Id = blogImage.Id,
                //    Title = blogImage.Title,
                //    DateCreated = blogImage.DateCreated,
                //    FileExtension = blogImage.FileExtension,
                //    FileName = blogImage.FileName,
                //    Url = blogImage.Url
                //};

                return Ok(imageFile);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png",".ico",".txt" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }
        }


    }
}
