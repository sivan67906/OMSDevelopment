using MediatR;

namespace ConfigurationServices.CQRS.Application.Feauters.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public int Id { get; set; }
    }
}


