using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessLocations.Commands.DeleteBusinessLocation;

internal class DeleteBusinessLocationCommandHandler : IRequestHandler<DeleteBusinessLocationCommand>
{
    private readonly IGenericRepository<BusinessLocation> _businessLocationRepository;

    public DeleteBusinessLocationCommandHandler(
        IGenericRepository<BusinessLocation> businessLocationRepository) =>
        _businessLocationRepository = businessLocationRepository;
    public async Task Handle(DeleteBusinessLocationCommand request, CancellationToken cancellationToken)
    {
        var businessLocation = new BusinessLocation
        {
            Id = request.Id,
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
            IsActive = request.IsActive
        };

        await _businessLocationRepository.DeleteAsync(businessLocation);
    }
}
