using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Commands.DeleteCountry;

internal class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand>
{
    private readonly IGenericRepository<CountryDTO> _countryRepository;

    public DeleteCountryCommandHandler(
        IGenericRepository<CountryDTO> countryRepository) =>
        _countryRepository = countryRepository;
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        await _countryRepository.DeleteAsync(request.Id);
    }
}












