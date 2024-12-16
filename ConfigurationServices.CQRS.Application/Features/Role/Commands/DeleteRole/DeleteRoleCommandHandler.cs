using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Roles.Commands.DeleteRole;

internal class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IGenericRepository<Role> _roleRepository;

    public DeleteRoleCommandHandler(
        IGenericRepository<Role> roleRepository) =>
        _roleRepository = roleRepository;
    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Id = request.Id,
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            CompanyId = request.CompanyId,
            DepartmentId = request.DepartmentId,
            DesignationId = request.DesignationId,
            IsActive = request.IsActive,
        };

        await _roleRepository.DeleteAsync(role);
    }
}



