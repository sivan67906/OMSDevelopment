using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessLocations.Queries.GetBusinessLocationById;

internal class GetBusinessLocationByIdQueryHandler : IRequestHandler<GetBusinessLocationByIdQuery, BusinessLocationDto>
{
    private readonly IGenericRepository<BusinessLocation> _businessLocationRepository;

    public GetBusinessLocationByIdQueryHandler(
        IGenericRepository<BusinessLocation> businessLocationRepository) =>
        _businessLocationRepository = businessLocationRepository;

    public async Task<BusinessLocationDto> Handle(GetBusinessLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var businessLocation = await _businessLocationRepository.GetByIdAsync(request.Id);
        if (businessLocation == null) return null;
        return new BusinessLocationDto
        {
            Id = businessLocation.Id,
            Code = businessLocation.Code,
            Name = businessLocation.Name,
            CompanyId = businessLocation.CompanyId,
            AddressId = businessLocation.AddressId,
            Address1 = businessLocation.Address.Address1,
            Address2 = businessLocation.Address.Address2,
            ZipCode = businessLocation.Address.ZipCode,
            Latitude = businessLocation.Address.Latitude,
            Longitude = businessLocation.Address.Longitude,
            CountryId = businessLocation.CountryId,
            StateId = businessLocation.StateId,
            CityId = businessLocation.CityId,
            CountryName = businessLocation.Country.Name,
            StateName = businessLocation.State.Name,
            CityName = businessLocation.City.Name,
            TaxName = businessLocation.TaxName,
            TaxNumber = businessLocation.TaxNumber,
            IsActive = businessLocation.IsActive
        };
    }
}
