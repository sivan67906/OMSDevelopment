using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumersByPhone
{
    public class GetSearchConsumersByPhoneQuery : IRequest<IEnumerable<ConsumerDTO>>
    {
        public string? PhoneNumber { get; set; }
    }
}
