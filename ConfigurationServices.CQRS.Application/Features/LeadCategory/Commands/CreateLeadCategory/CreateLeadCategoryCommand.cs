using MediatR;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadCategory.Commands.CreateLeadCategory
{
    public class CreateLeadCategoryCommand : IRequest<int>
    {
        
        public string? CategoryName { get; set; }
    }
}


