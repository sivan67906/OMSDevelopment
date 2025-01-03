using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Roles.Commands.CreateRole;

internal class CreateRoleCommandHandler(
    IGenericRepository<Role> roleRepository) : IRequestHandler<CreateRoleCommand>
{
    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            CompanyId = request.CompanyId,
            DepartmentId = request.DepartmentId,
            DesignationId = request.DesignationId,
            CreatedDate = DateTime.Now,
            IsActive = request.IsActive,
        };

        await roleRepository.CreateAsync(role);
    }
}



