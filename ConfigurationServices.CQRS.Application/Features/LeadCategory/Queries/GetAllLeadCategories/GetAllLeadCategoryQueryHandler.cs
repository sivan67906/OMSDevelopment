using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Interfaces;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadCategory.Queries.GetAllLeadCategories
{
    public class GetAllLeadCategoryQueryHandler : IRequestHandler<GetAllLeadCategoryQuery, IEnumerable<LeadCategoryDTO>>
    {
        private readonly IGenericRepository<Domain.Entities.LeadCategory> _repository;
        public GetAllLeadCategoryQueryHandler(IGenericRepository<Domain.Entities.LeadCategory> repository) => _repository = repository;

        public async Task<IEnumerable<LeadCategoryDTO>> Handle(GetAllLeadCategoryQuery request, CancellationToken cancellationToken)
        {
            var categorys = await _repository.GetAllAsync();

            var categorylist = categorys.Select(x => new LeadCategoryDTO
            {
                Id = x.Id,
                CategoryName = x.CategoryName
                
            }).ToList();

            return categorylist;
        }
    }
}


