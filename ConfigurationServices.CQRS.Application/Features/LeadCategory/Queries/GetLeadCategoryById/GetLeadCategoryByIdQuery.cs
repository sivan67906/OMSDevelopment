using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadCategory.Queries.GetLeadCategoryById
{
    public class GetLeadCategoryByIdQuery : IRequest<LeadCategoryDTO>
    {
        public int Id { get; set; }
    }
}


