using MediatR;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadAgent.Commands.UpdateLeadAgent
{
    public class UpdateLeadAgentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? AgentName { get; set; }
    }
}


