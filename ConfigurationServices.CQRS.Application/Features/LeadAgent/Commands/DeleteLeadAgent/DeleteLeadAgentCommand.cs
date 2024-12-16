using MediatR;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadAgent.Commands.DeleteLeadAgent
{
    public class DeleteLeadAgentCommand : IRequest
    {
        public int Id { get; set; }
    }
}


