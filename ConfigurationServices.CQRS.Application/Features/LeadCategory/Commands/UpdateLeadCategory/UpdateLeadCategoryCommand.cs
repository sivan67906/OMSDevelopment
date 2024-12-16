using MediatR;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadCategory.Commands.UpdateLeadCategory
{
    public class UpdateLeadCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
    }
}


