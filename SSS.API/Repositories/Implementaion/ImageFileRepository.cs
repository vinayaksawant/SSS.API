using SSS.API.Data;
using SSS.API.Models.Domain;
using SSS.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace SSS.API.Repositories.Implementaion
{
    public class ImageFileRepository : IImageFileRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ApplicationDbContext dbContext;

        public ImageFileRepository(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            ApplicationDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ImageFile>> GetAll()
        {
            return await dbContext.ImageFiles.ToListAsync();
        }

        public async Task<ImageFile> Upload(IFormFile file, ImageFile imageFile)
        {
            // 1- Upload the Image to API/Images
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{imageFile.ImageFileName}{imageFile.ImageFileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            // 2-Update the database
            // https://codepulse.com/images/somefilename.jpg
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{imageFile.ImageFileName}{imageFile.ImageFileExtension}";

            imageFile.ImageFileUrl = urlPath;

            await dbContext.ImageFiles.AddAsync(imageFile);
            await dbContext.SaveChangesAsync();

            return imageFile;
        }
    }
}
