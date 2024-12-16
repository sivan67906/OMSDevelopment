using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Designations.Queries.GetDesignationById
{
    public class GetDesignationByIdQuery : IRequest<DesignationDto>
    {
        public int Id { get; set; }
    }
}




