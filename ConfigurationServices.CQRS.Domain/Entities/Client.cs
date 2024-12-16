using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationServices.CQRS.Domain.Entities
{
    public sealed class Client
    {
        public int Id { get; set; }
        public string? ClientCode { get; set; }
        public string? ClientName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public int ZipCode { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        //[ForeignKey(nameof(AddressId))]
        //public int? AddressId { get; set; }
        //public Address? Address { get; set; }

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        [ForeignKey(nameof(StateId))]
        public int StateId { get; set; }
        public State? State { get; set; }

        [ForeignKey(nameof(CityId))]
        public int CityId { get; set; }
        public City? City { get; set; }

    }
}
