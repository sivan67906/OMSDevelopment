using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfigurationServices.CQRS.Domain.Entities;

public sealed class LocationLevel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int? Parent_Id { get; set; }
    public DateTime Created_Date { get; set; }
    public DateTime? Modified_Date { get; set; }
    public bool Isactive { get; set; }

    public ICollection<Location>? Locations { get; set; }
}