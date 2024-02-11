namespace SSS.API.Models.Domain
{
    public class LinkHandle
    {
        public Guid Id { get; set; }
        public string LinkHandleName { get; set; }
        public string LinkHandleTitle { get; set; }
        public string LinkHandleUrl { get; set; }
        public string LinkHandleType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
