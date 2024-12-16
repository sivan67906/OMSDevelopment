using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumerById
{
    public class GetSearchConsumerByIdQuery : IRequest<ConsumerDto>
    {
        public int Id { get; set; }
    }
}
