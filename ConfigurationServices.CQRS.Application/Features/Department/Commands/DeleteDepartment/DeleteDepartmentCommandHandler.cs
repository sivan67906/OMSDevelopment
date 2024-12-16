using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Departments.Commands.DeleteDepartment;

internal class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IGenericRepository<Department> _departmentRepository;

    public DeleteDepartmentCommandHandler(
        IGenericRepository<Department> departmentRepository) =>
        _departmentRepository = departmentRepository;
    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = new Department
        {
            Id = request.Id,
            Code = request.Code,
            Name = request.Name,
            CompanyId = request.CompanyId,
            Email = request.Email,
            Description = request.Description,
            IsActive = request.IsActive
        };

        //await _departmentRepository.DeleteAsync(department);
    }
}
