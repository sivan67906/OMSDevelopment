using ConfigurationServices.CQRS.Domain.Entities;

namespace ConfigurationServices.CQRS.Application.Services
{
    public interface ILeadStatusService
    {
        Task<LeadStatus> GetByLeadStatusNameAsync(string leadStatus);
        Task<IEnumerable<LeadStatus>> SearchLeadStatusByNameAsync(string leadStatus);
        Task UpdateLeadStatusAsync(LeadStatus leadStatus);
    }
}
