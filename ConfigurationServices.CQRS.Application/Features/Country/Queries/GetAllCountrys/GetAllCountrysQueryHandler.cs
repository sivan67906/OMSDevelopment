using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Queries.GetAllCountries;

internal class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDto>>
{
    private readonly IGenericRepository<CountryDto> _countryRepository;

    public GetAllCountriesQueryHandler(
        IGenericRepository<CountryDto> countryRepository) =>
        _countryRepository = countryRepository;

    public async Task<IEnumerable<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _countryRepository.GetAllAsync();

        var countryList = companies.Select(x => new CountryDto
        {
            Id = x.Id,
            Name = x.Name,
            Code = x.Code,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return countryList;
    }
}












