using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.States.Queries.GetStateById
{
    public class GetStateByIdQuery : IRequest<StateDTO>
    {
        public int Id { get; set; }
    }
}












