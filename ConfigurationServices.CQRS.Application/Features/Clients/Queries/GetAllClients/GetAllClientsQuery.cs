using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;

namespace ConfigurationServices.CQRS.Application.Feauters.Clients.Queries.GetAllClients
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDTO>>
    {

    }
}


