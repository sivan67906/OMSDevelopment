using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryCommand : IRequest
{
    public string Name { get; set; }
}












