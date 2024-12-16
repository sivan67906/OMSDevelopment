using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.PlanTypes.Queries.GetAllPlanTypes;

internal class GetAllPlanTypesQueryHandler : IRequestHandler<GetAllPlanTypesQuery, IEnumerable<PlanTypeDto>>
{
    private readonly IGenericRepository<PlanType> _planTypeRepository;

    public GetAllPlanTypesQueryHandler(
        IGenericRepository<PlanType> planTypeRepository) =>
        _planTypeRepository = planTypeRepository;

    public async Task<IEnumerable<PlanTypeDto>> Handle(GetAllPlanTypesQuery request, CancellationToken cancellationToken)
    {
        var planType = await _planTypeRepository.GetAllAsync();

        var planTypes = planType.Select(x => new PlanTypeDto
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name
        }).ToList();

        return planTypes;
    }
}