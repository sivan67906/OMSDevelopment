using ConfigurationServices.CQRS.Domain.Entities;

namespace ConfigurationServices.CQRS.Application.Services
{
    public interface ILeadAgentService
    {
        Task<LeadAgent> GetByLeadAgentNameAsync(string leadAgent);
        Task<IEnumerable<LeadAgent>> SearchLeadAgentByNameAsync(string leadAgent);
        Task UpdateLeadAgentAsync(LeadAgent agent);
    }
}
