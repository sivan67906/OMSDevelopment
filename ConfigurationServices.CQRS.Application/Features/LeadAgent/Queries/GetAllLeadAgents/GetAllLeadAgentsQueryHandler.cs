using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Interfaces;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadAgent.Queries.GetAllLeadAgents
{
    public class GetAllLeadAgentsQueryHandler : IRequestHandler<GetAllLeadAgentsQuery, IEnumerable<LeadAgentDTO>>
    {
        public readonly IGenericRepository<Domain.Entities.LeadAgent> _repository;
        public GetAllLeadAgentsQueryHandler(IGenericRepository<Domain.Entities.LeadAgent> repository) => _repository = repository;

        public async Task<IEnumerable<LeadAgentDTO>> Handle(GetAllLeadAgentsQuery request, CancellationToken cancellationToken)
        {
            var agent = await _repository.GetAllAsync();

            var agentList = agent.Select(x => new LeadAgentDTO
            {
                Id = x.Id,
                AgentName = x.AgentName,
            }).ToList();

            return agentList;
        }
    }
}


