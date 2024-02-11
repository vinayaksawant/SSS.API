namespace SSS.API.Models.Domain
{
    public class Employer
    {
        public Guid Id { get; set; }
        public Member MemberOrganization { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<LinkHandle> LinkHandles { get; set; }

        public ICollection<ImageFile> ImageFiles { get; set; }
    }
}
