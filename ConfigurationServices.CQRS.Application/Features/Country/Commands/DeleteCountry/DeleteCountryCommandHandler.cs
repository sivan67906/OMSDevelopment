using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Commands.DeleteCountry;

internal class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand>
{
    private readonly IGenericRepository<CountryDto> _countryRepository;

    public DeleteCountryCommandHandler(
        IGenericRepository<CountryDto> countryRepository) =>
        _countryRepository = countryRepository;
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        await _countryRepository.DeleteAsync(request.Id);
    }
}












