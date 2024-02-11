using Microsoft.EntityFrameworkCore;

namespace SSS.API.Models.Domain
{
    public class ImageFile
    {
        public Guid Id { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFileExtension { get; set; }
        public string ImageFileTitle { get; set; }
        public string ImageFileUrl { get; set; }
        public string ImageFileType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
