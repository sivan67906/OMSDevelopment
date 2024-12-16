using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Queries.GetCountryById;

internal class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, CountryDTO>
{
    private readonly IGenericRepository<CountryDTO> _countryRepository;

    public GetCountryByIdQueryHandler(
        IGenericRepository<CountryDTO> countryRepository) =>
        _countryRepository = countryRepository;

    public async Task<CountryDTO> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetByIdAsync(request.Id);
        if (country == null) return null;
        return new CountryDTO
        {
        };
    }
}












