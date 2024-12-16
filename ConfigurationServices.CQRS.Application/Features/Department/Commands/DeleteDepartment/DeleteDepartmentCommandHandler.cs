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
        await _departmentRepository.DeleteAsync(request.Id);
    }
}
