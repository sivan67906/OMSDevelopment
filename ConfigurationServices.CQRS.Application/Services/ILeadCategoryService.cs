using ConfigurationServices.CQRS.Domain.Entities;

namespace ConfigurationServices.CQRS.Application.Services
{
    public interface ILeadCategoryService
    {
        Task<LeadCategory> GetByCategoryNameAsync(string categoryName);
        Task<IEnumerable<LeadCategory>> SearchCategoryByNameAsync(string categoryName);
        Task UpdateCategoryAsync(LeadCategory category);
    }
}
