namespace SSS.API.Models.DTO
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string DocumentType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
