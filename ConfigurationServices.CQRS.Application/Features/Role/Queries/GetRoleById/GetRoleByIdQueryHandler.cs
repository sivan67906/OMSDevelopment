using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Roles.Queries.GetRoleById;

internal class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
{
    private readonly IGenericRepository<Role> _roleRepository;

    public GetRoleByIdQueryHandler(
        IGenericRepository<Role> roleRepository) =>
        _roleRepository = roleRepository;

    public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.Id);
        if (role == null) return null;
        return new RoleDto
        {
            Id = role.Id,
            Code = role.Code,
            Name = role.Name,
            Description = role.Description,
            CompanyId = role.CompanyId,
            DepartmentId = role.DepartmentId,
            DesignationId = role.DesignationId,
            CreatedDate = role.CreatedDate,
            UpdatedDate = role.UpdatedDate,
            IsActive = role.IsActive
        };
    }
}



