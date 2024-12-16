using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Roles.Queries.GetAllRoles;

internal class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
{
    private readonly IGenericRepository<Role> _roleRepository;

    public GetAllRolesQueryHandler(
        IGenericRepository<Role> roleRepository) =>
        _roleRepository = roleRepository;

    public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _roleRepository.GetAllAsync();

        var roleList = companies.Select(x => new RoleDto
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            Description = x.Description,
            CompanyId = x.CompanyId,
            DepartmentId = x.DepartmentId,
            DesignationId = x.DesignationId,
            CompanyName = x.Company.Name,
            DepartmentName = x.Department.Name,
            DesignationName = x.Designation.Name,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return roleList;
    }
}



