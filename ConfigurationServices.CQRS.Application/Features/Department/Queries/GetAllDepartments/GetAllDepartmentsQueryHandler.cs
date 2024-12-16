using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Application.Features.Departments.Queries.GetAllDepartments;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.x.Queries.GetAllDepartments;

internal class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
{
    private readonly IGenericRepository<Department> _departmentRepository;

    public GetAllDepartmentsQueryHandler(
        IGenericRepository<Department> departmentRepository) =>
        _departmentRepository = departmentRepository;

    public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await _departmentRepository.GetAllAsync();

        var departmentList = departments.Select(x => new DepartmentDto
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            CompanyId = x.CompanyId,
            CompanyName = x.Company.Name,
            Email = x.Email,
            Description = x.Description,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return departmentList;
    }
}
