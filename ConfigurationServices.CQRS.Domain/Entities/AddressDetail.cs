using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationServices.CQRS.Domain.Entities;

public sealed class AddressDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Landmark { get; set; }
    public string? Pincode { get; set; }
    public int? City { get; set; }
    public string? District { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Region { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public int? TypeId { get; set; }
    public int? TypeLOVId { get; set; }
    public int? LocationId { get; set; }
    public bool IsPrimary { get; set; }
    public DateTime? Effective_From { get; set; }
    public DateTime? Effective_To { get; set; }
    public DateTime Created_Date { get; set; }
    public DateTime? Modified_Date { get; set; }
    public bool Isactive { get; set; }

    [ForeignKey(nameof(LocationId))]
    public Location? Location { get; set; }
}