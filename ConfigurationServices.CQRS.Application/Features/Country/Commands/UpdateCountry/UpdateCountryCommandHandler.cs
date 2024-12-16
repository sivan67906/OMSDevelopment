using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Commands.UpdateCountry;

internal class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand>
{
    private readonly IGenericRepository<CountryDto> _countryRepository;

    public UpdateCountryCommandHandler(
        IGenericRepository<CountryDto> countryRepository) =>
        _countryRepository = countryRepository;

    public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new CountryDto
        {
        };

        await _countryRepository.UpdateAsync(country);
    }
}












