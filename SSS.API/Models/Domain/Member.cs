namespace SSS.API.Models.Domain
{
    public class Member
    {
        public Guid Id { get; set; } 

        public string OrgName { get; set; }
        public string Description { get; set; } 
        public Boolean  Individual { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Title { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Email> Emails { get; set; }

        public ICollection<Phone> Phones { get; set; }  

    }
}
