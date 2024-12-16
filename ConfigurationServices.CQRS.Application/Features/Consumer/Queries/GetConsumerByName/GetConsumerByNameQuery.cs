using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Queries.GetConsumerByName
{
    public class GetConsumerByNameQuery : IRequest<ConsumerDTO>
    {
        public string? ConsumerName { get; set; }
    }
}
