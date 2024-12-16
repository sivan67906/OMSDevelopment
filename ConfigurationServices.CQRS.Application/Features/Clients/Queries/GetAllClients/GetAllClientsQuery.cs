using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;

namespace ConfigurationServices.CQRS.Application.Feauters.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDTO>>
    {
        public string? Address1 { get;  set; }
        public string? Address2 { get;  set; }
    }
}


