namespace ConfigurationServices.CQRS.Application.DTOs;

public class PlanTypeDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    //public ConsumerDto? ConsumerSingle { get; set; }
}
