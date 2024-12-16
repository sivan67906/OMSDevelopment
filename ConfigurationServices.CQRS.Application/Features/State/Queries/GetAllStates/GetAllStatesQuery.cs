using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.States.Queries.GetAllStates;

public class GetAllStatesQuery : IRequest<IEnumerable<StateDTO>>
{
}












