using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumersByName
{
    public class GetSearchConsumersByNameQuery : IRequest<IEnumerable<ConsumerDTO>>
    {
        public string? ConsumerName { get; set; }
    }
}
