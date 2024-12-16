using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumersByDate
{
    public class GetSearchConsumersByDateQuery : IRequest<IEnumerable<ConsumerDTO>>
    {
        public DateTime SearchDate { get; set; }
    }
}
