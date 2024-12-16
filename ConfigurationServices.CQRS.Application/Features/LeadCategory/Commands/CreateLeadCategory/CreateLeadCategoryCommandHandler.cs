using MediatR;
using ConfigurationServices.CQRS.Domain.Interfaces;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadCategory.Commands.CreateLeadCategory
{
    public class CreateLeadCategoryCommandHandler : IRequestHandler<CreateLeadCategoryCommand, int>
    {
        private readonly IGenericRepository<Domain.Entities.LeadCategory> _repository;
        public CreateLeadCategoryCommandHandler(IGenericRepository<Domain.Entities.LeadCategory> repository) => _repository = repository;

        public async Task<int> Handle(CreateLeadCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.LeadCategory
            {
                CategoryName = request.CategoryName,
                
            };

            await _repository.CreateAsync(product);
            return product.Id;
        }
    }
}


