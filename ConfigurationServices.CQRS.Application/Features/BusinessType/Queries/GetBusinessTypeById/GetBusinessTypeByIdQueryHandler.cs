using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessTypes.Queries.GetBusinessTypeById;

internal class GetBusinessTypeByIdQueryHandler : IRequestHandler<GetBusinessTypeByIdQuery, BusinessTypeDto>
{
    private readonly IGenericRepository<BusinessType> _businessTypeRepository;

    public GetBusinessTypeByIdQueryHandler(
        IGenericRepository<BusinessType> businessTypeRepository) =>
        _businessTypeRepository = businessTypeRepository;

    public async Task<BusinessTypeDto> Handle(GetBusinessTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var businessType = await _businessTypeRepository.GetByIdAsync(request.Id);
        if (businessType == null) return null;
        return new BusinessTypeDto
        {
        };
    }
}





