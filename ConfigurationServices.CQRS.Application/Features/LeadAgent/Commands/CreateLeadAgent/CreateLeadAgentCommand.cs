using MediatR;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadAgent.Commands.CreateLeadAgent
{
    public class CreateLeadAgentCommand : IRequest<int>
    {
        public string? AgentName { get; set; }
    }
}


