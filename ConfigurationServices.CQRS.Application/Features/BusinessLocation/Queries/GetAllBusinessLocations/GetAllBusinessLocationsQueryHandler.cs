﻿using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessLocations.Queries.GetAllBusinessLocations;

internal class GetAllBusinessLocationsQueryHandler : IRequestHandler<GetAllBusinessLocationsQuery, IEnumerable<BusinessLocationDTO>>
{
    private readonly IGenericRepository<BusinessLocation> _businessLocationRepository;

    public GetAllBusinessLocationsQueryHandler(
        IGenericRepository<BusinessLocation> businessLocationRepository) =>
        _businessLocationRepository = businessLocationRepository;

    public async Task<IEnumerable<BusinessLocationDTO>> Handle(GetAllBusinessLocationsQuery request, CancellationToken cancellationToken)
    {
        var companies = await _businessLocationRepository.GetAllAsync();

        var businessLocationList = companies.Select(x => new BusinessLocationDTO
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            CompanyId = x.CompanyId,
            AddressId = x.AddressId,
            Address1 = x.Address.Address1,
            Address2 = x.Address.Address2,
            ZipCode = x.Address.ZipCode,
            Latitude = x.Address.Latitude,
            Longitude = x.Address.Longitude,
            CountryId = x.CountryId,
            StateId = x.StateId,
            CityId = x.CityId,
            CountryName = x.Country.Name,
            StateName = x.State.Name,
            CityName = x.City.Name,
            TaxName = x.TaxName,
            TaxNumber = x.TaxNumber,
            IsActive = x.IsActive
        }).ToList();

        return businessLocationList;
    }
}
