using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Designations.Queries.GetAllDesignations;

public class GetAllDesignationsQuery : IRequest<IEnumerable<DesignationDto>>
{
}




