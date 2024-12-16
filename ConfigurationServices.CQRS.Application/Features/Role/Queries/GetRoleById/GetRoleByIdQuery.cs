using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQuery : IRequest<RoleDto>
    {
        public int Id { get; set; }
    }
}



