using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
    {
        public int Id { get; set; }
    }
}
