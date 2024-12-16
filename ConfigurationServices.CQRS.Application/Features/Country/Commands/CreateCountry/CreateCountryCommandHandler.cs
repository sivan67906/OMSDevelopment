using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Commands.CreateCountry;

internal class CreateCountryCommandHandler(
    IGenericRepository<CountryDTO> countryRepository) : IRequestHandler<CreateCountryCommand>
{
    public async Task Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new CountryDTO
        {
            Name = request.Name
        };

        await countryRepository.CreateAsync(country);
    }
}












