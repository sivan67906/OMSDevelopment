using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
{
}



