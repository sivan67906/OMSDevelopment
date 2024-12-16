using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessLocations.Queries.GetAllBusinessLocations;

public class GetAllBusinessLocationsQuery : IRequest<IEnumerable<BusinessLocationDTO>>
{
}
