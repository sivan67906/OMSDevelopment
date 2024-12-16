namespace ConfigurationServices.CQRS.Domain.Entities
{
    public sealed class LeadSource
    {
        public int Id { get; set; }
        public string? source { get; set; }
    }
}
