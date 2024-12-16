using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Queries.GetConsumerByName
{
    public class GetConsumerByNameQuery : IRequest<ConsumerDto>
    {
        public string? ConsumerName { get; set; }
    }
}
