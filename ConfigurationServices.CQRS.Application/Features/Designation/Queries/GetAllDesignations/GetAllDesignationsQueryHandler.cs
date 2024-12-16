using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Designations.Queries.GetAllDesignations;

internal class GetAllDesignationsQueryHandler : IRequestHandler<GetAllDesignationsQuery, IEnumerable<DesignationDto>>
{
    private readonly IGenericRepository<Designation> _designationRepository;

    public GetAllDesignationsQueryHandler(
        IGenericRepository<Designation> designationRepository) =>
        _designationRepository = designationRepository;

    public async Task<IEnumerable<DesignationDto>> Handle(GetAllDesignationsQuery request, CancellationToken cancellationToken)
    {
        var designations = await _designationRepository.GetAllAsync();

        var designationList = designations.Select(x => new DesignationDto
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            CompanyId = x.CompanyId,
            DepartmentId = x.DepartmentId,
            CompanyName = x.Company.Name,
            DepartmentName = x.Department.Name,
            Description = x.Description,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return designationList;
    }
}




