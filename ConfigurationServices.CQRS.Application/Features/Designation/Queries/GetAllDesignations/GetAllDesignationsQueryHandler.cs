using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Designations.Queries.GetAllDesignations;

internal class GetAllDesignationsQueryHandler : IRequestHandler<GetAllDesignationsQuery, IEnumerable<DesignationDto>>
{
    private readonly IGenericRepository<Role> _roleRepository;

    public GetAllDesignationsQueryHandler(
        IGenericRepository<Role> roleRepository) =>
        _roleRepository = roleRepository;

    public async Task<IEnumerable<DesignationDto>> Handle(GetAllDesignationsQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllAsync();

        var roleList = roles.Select(x => new DesignationDto
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            CompanyId = x.CompanyId,
            DepartmentId = x.DepartmentId,
            Description = x.Description,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return roleList;
    }
}




