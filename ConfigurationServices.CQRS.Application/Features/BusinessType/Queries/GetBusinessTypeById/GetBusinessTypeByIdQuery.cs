using ConfigurationServices.CQRS.Domain.Entities;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessTypes.Queries.GetBusinessTypeById
{
    public class GetBusinessTypeByIdQuery : IRequest<BusinessTypeDto>
    {
        public int Id { get; set; }
    }
}





