namespace ConfigurationServices.CQRS.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string? ClientCode { get; set; }
        public string? ClientName { get; set; }
        public string? Email { get; set; }
        public int CompanyId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address1 { get; set; } 
        public string? Address2 { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string? Description { get; set; }
        public int ZipCode { get; set; }

    }
}


