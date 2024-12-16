using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadAgent.Queries.GetAllLeadAgents
{
    public class GetAllLeadAgentsQuery : IRequest<IEnumerable<LeadAgentDTO>>
    {
    }
}


