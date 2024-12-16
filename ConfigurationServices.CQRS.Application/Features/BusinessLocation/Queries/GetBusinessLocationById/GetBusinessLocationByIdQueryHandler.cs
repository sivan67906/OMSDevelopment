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
            CompanyId = businessLocation.CompanyId,
            Name = businessLocation.Name,
            Address1 = businessLocation.Address1,
            Address2 = businessLocation.Address2,
            CountryId = businessLocation.CountryId,
            StateId = businessLocation.StateId,
            CityId = businessLocation.CityId,
            ZipCode = businessLocation.ZipCode,
            TaxName = businessLocation.TaxName,
            TaxNumber = businessLocation.TaxNumber,
            Latitude = businessLocation.Latitude,
            Longitude = businessLocation.Longitude,
            CreatedDate = businessLocation.CreatedDate,
            UpdatedDate = businessLocation.UpdatedDate,
            IsActive = businessLocation.IsActive,
        };
    }
}
