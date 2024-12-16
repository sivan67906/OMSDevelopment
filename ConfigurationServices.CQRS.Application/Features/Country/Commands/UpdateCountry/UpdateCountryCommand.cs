using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}












