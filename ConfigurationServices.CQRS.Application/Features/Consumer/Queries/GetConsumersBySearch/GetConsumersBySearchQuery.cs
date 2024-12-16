using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Queries.GetConsumersBySearch
{
    public class GetConsumersBySearchQuery : IRequest<IEnumerable<ConsumerDto>>
    {
        public string? ConsumerName { get; set; }
    }
}