using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;

namespace ConfigurationServices.CQRS.Application.Feauters.Clients.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientDTO>
    {
        public int Id { get; set; }
    }
}


