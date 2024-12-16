using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Designations.Commands.DeleteDesignation;

internal class DeleteDesignationCommandHandler : IRequestHandler<DeleteDesignationCommand>
{
    private readonly IGenericRepository<Designation> _designationRepository;

    public DeleteDesignationCommandHandler(
        IGenericRepository<Designation> designationRepository) =>
        _designationRepository = designationRepository;
    public async Task Handle(DeleteDesignationCommand request, CancellationToken cancellationToken)
    {
        var designation = new Designation
        {
            Id = request.Id,
            Code = request.Code,
            Name = request.Name,
            CompanyId = request.CompanyId,
            DepartmentId = request.DepartmentId,
            Description = request.Description,
            IsActive = request.IsActive
        };

        //await _designationRepository.DeleteAsync(designation);
    }
}




