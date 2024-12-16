using MediatR;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadAgent.Commands.CreateLeadAgent
{
    public class CreateLeadAgentCommandHandler : IRequestHandler<CreateLeadAgentCommand, int>
    {
        private readonly IGenericRepository<Domain.Entities.LeadAgent> _leadagentRepository;
        public CreateLeadAgentCommandHandler(IGenericRepository<Domain.Entities.LeadAgent> leadagentRepository) => _leadagentRepository = leadagentRepository;

        public async Task<int> Handle(CreateLeadAgentCommand request, CancellationToken cancellationToken)
        {
            var leadAgent = new Domain.Entities.LeadAgent
            {
                AgentName = request.AgentName,
                
            };

            await _leadagentRepository.CreateAsync(leadAgent);
            return leadAgent.Id;
        }
    }
}


