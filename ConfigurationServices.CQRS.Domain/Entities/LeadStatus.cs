namespace ConfigurationServices.CQRS.Domain.Entities
{
    public sealed class LeadStatus
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Color { get; set; }
    }
}
