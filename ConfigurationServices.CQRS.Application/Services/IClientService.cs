using ConfigurationServices.CQRS.Domain.Entities;

namespace ConfigurationServices.CQRS.Application.Services
{
    public interface IClientService
    {
        Task<Client> GetByLeadAgentNameAsync(string client);
        Task<IEnumerable<Client>> SearchLeadAgentByNameAsync(string client);
        Task UpdateLeadAgentAsync(Client client);
    }
}
