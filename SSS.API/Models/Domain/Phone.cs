namespace SSS.API.Models.Domain
{
    public class Phone
    {
        public Guid id { get; set; }
        public string PhoneAreaCode { get; set; }
        public string PhoneLocalStdIsd { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
    }
}
