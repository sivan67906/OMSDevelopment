using MediatR;
using ConfigurationServices.CQRS.Domain.Interfaces;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadAgent.Commands.UpdateLeadAgent
{
    public class UpdateLeadAgentCommandHandler : IRequestHandler<UpdateLeadAgentCommand,int>
    {
        private readonly IGenericRepository<Domain.Entities.LeadAgent> _repository;
        public UpdateLeadAgentCommandHandler(IGenericRepository<Domain.Entities.LeadAgent> repository) => _repository = repository;

        public async Task<int> Handle(UpdateLeadAgentCommand request, CancellationToken cancellationToken)
        {
            var leadAgent = new Domain.Entities.LeadAgent
            {
                Id = request.Id,
                AgentName = request.AgentName,
            };
            await _repository.UpdateAsync(leadAgent);
            return request.Id;
        }
    }
}


