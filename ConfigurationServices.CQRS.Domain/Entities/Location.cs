using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationServices.CQRS.Domain.Entities;

public sealed class Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public int? Parent_Id { get; set; }
    public int? LocationLevelId { get; set; }
    public DateTime Created_Date { get; set; }
    public DateTime? Modified_Date { get; set; }
    public bool Isactive { get; set; }

    [ForeignKey(nameof(LocationLevelId))]
    public LocationLevel? locationLevel { get; set; }
    public ICollection<AddressDetail>? AddressDetails { get; set; }
}