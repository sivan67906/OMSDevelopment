using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessLocations.Commands.CreateBusinessLocation;

internal class CreateBusinessLocationCommandHandler(
    IGenericRepository<BusinessLocation> businessLocationRepository) : IRequestHandler<CreateBusinessLocationCommand>
{
    public async Task Handle(CreateBusinessLocationCommand request, CancellationToken cancellationToken)
    {
        var businessLocation = new BusinessLocation
        {
            CompanyId = request.CompanyId,
            Name = request.Name,
            Address1 = request.Address1,
            Address2 = request.Address2,
            CountryId = request.CountryId,
            StateId = request.StateId,
            CityId = request.CityId,
            ZipCode = request.ZipCode,
            TaxName = request.TaxName,
            TaxNumber = request.TaxNumber,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsActive = request.IsActive
        };

        await businessLocationRepository.CreateAsync(businessLocation);
    }
}
