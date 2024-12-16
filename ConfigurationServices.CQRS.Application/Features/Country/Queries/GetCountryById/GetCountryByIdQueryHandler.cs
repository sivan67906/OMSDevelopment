using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Queries.GetCountryById;

internal class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, CountryDto>
{
    private readonly IGenericRepository<CountryDto> _countryRepository;

    public GetCountryByIdQueryHandler(
        IGenericRepository<CountryDto> countryRepository) =>
        _countryRepository = countryRepository;

    public async Task<CountryDto> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetByIdAsync(request.Id);
        if (country == null) return null;
        return new CountryDto
        {
        };
    }
}












