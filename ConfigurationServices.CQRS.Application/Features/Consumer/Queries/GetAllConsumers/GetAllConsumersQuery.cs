using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Queries.GetAllConsumers;

public class GetAllConsumersQuery : IRequest<IEnumerable<ConsumerDTO>>
{
}
