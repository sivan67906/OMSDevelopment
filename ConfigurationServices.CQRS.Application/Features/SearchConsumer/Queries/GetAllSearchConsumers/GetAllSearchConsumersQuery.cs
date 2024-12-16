using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetAllSearchConsumers;

public class GetAllSearchConsumersQuery : IRequest<IEnumerable<ConsumerDto>>
{
}
