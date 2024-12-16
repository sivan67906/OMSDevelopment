using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessLocations.Queries.GetBusinessLocationById
{
    public class GetBusinessLocationByIdQuery : IRequest<BusinessLocationDTO>
    {
        public int Id { get; set; }
    }
}
