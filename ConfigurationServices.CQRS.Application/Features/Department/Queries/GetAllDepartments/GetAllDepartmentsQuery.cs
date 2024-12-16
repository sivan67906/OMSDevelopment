using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
{

}
