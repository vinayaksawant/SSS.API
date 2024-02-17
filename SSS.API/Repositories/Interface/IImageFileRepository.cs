using SSS.API.Models.Domain;

namespace SSS.API.Repositories.Interface
{
    public interface IImageFileRepository
    {
        Task<ImageFile> Upload(IFormFile file, ImageFile imageFile);

        Task<IEnumerable<ImageFile>> GetAll();

    }
}
