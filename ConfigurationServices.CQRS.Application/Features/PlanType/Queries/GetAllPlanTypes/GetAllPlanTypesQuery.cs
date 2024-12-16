using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.PlanTypes.Queries.GetAllPlanTypes;

public class GetAllPlanTypesQuery : IRequest<IEnumerable<PlanTypeDto>>
{
}
