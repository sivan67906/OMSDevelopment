using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Departments.Commands.CreateDepartment;

internal class CreateDepartmentCommandHandler(
    IGenericRepository<Department> companyRepository) : IRequestHandler<CreateDepartmentCommand>
{
    public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = new Department
        {
            Code = request.Code,
            Name = request.Name,
            CompanyId = request.CompanyId,
            Email = request.Email,
            Description = request.Description,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsActive = request.IsActive
        };

        await companyRepository.CreateAsync(department);
    }
}
