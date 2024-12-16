using MediatR;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadCategory.Commands.DeleteLeadCategory
{
    public class DeleteLeadCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}


