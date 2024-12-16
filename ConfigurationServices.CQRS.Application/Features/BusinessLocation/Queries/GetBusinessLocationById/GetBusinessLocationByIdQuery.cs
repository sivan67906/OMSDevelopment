using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessLocations.Queries.GetBusinessLocationById
{
    public class GetBusinessLocationByIdQuery : IRequest<BusinessLocationDto>
    {
        public int Id { get; set; }
    }
}
