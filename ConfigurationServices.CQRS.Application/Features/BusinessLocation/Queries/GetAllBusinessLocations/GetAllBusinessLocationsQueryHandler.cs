using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessLocations.Queries.GetAllBusinessLocations;

internal class GetAllBusinessLocationsQueryHandler : IRequestHandler<GetAllBusinessLocationsQuery, IEnumerable<BusinessLocationDto>>
{
    private readonly IGenericRepository<BusinessLocation> _businessLocationRepository;

    public GetAllBusinessLocationsQueryHandler(
        IGenericRepository<BusinessLocation> businessLocationRepository) =>
        _businessLocationRepository = businessLocationRepository;

    public async Task<IEnumerable<BusinessLocationDto>> Handle(GetAllBusinessLocationsQuery request, CancellationToken cancellationToken)
    {
        var companies = await _businessLocationRepository.GetAllAsync();

        var businessLocationList = companies.Select(x => new BusinessLocationDto
        {
            Id = x.Id,
            CompanyId = x.CompanyId,
            Name = x.Name,
            Address1 = x.Address1,
            Address2 = x.Address2,
            CountryId = x.CountryId,
            StateId = x.StateId,
            CityId = x.CityId,
            ZipCode = x.ZipCode,
            TaxName = x.TaxName,
            TaxNumber = x.TaxNumber,
            Latitude = x.Latitude,
            Longitude = x.Longitude,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return businessLocationList;
    }
}
