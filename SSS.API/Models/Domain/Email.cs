using Microsoft.Identity.Client;

namespace SSS.API.Models.Domain
{
    public class Email
    {
        public Guid id { get; set; }
        public string EmailAddress { get; set; }
        public string EmailType { get; set; }
    }
}
