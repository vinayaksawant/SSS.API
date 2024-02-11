namespace SSS.API.Models.Domain
{
    public class Document
    {
        public Guid Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentExtension { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentUrl { get; set; }
        public string DocumentType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
