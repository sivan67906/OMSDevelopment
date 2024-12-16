using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessTypes.Queries.GetAllBusinessTypes;

internal class GetAllBusinessTypesQueryHandler : IRequestHandler<GetAllBusinessTypesQuery, IEnumerable<BusinessTypeDto>>
{
    private readonly IGenericRepository<BusinessType> _businessTypeRepository;

    public GetAllBusinessTypesQueryHandler(
        IGenericRepository<BusinessType> businessTypeRepository) =>
        _businessTypeRepository = businessTypeRepository;

    public async Task<IEnumerable<BusinessTypeDto>> Handle(GetAllBusinessTypesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _businessTypeRepository.GetAllAsync();

        var businessTypeList = companies.Select(x => new BusinessTypeDto
        {
            Id = x.Id,
            Name = x.Name,
            Code = x.Code,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return businessTypeList;
    }
}





