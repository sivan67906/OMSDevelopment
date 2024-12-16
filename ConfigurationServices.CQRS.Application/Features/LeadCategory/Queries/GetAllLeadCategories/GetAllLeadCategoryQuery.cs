using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadCategory.Queries.GetAllLeadCategories
{
    public class GetAllLeadCategoryQuery : IRequest<IEnumerable<LeadCategoryDTO>>
    {
    }
}


