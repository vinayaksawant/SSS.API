namespace SSS.API.Models.Domain
{
    public class Address
    {
        public Guid id { get; set; }    
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Takula { get; set; }
        public string Region { get; set; }
        public string County { get; set; }

        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public  string AddressType { get; set; }  


    }
}
