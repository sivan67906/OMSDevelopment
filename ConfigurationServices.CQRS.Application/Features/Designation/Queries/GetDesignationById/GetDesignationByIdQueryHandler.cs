using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Designations.Queries.GetDesignationById;

internal class GetDesignationByIdQueryHandler : IRequestHandler<GetDesignationByIdQuery, DesignationDto>
{
    private readonly IGenericRepository<Designation> _designationRepository;

    public GetDesignationByIdQueryHandler(
        IGenericRepository<Designation> designationRepository) =>
        _designationRepository = designationRepository;

    public async Task<DesignationDto> Handle(GetDesignationByIdQuery request, CancellationToken cancellationToken)
    {
        var designation = await _designationRepository.GetByIdAsync(request.Id);
        if (designation == null) return null;
        return new DesignationDto
        {
            Id = designation.Id,
            Code = designation.Code,
            Name = designation.Name,
            CompanyId = designation.CompanyId,
            DepartmentId = designation.DepartmentId,
            Description = designation.Description,
            CreatedDate = designation.CreatedDate,
            UpdatedDate = designation.UpdatedDate,
            IsActive = designation.IsActive
        };
    }
}




