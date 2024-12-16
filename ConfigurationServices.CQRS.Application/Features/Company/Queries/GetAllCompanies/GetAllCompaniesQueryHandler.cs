using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Companies.Queries.GetAllCompanies;

internal class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyDto>>
{
    private readonly IGenericRepository<Company> _companyRepository;

    public GetAllCompaniesQueryHandler(
        IGenericRepository<Company> companyRepository) =>
        _companyRepository = companyRepository;

    public async Task<IEnumerable<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyRepository.GetAllAsync();

        var companyList = companies.Select(x => new CompanyDto
        {
            Id = x.Id,
            Name = x.Name,
            RegnNumber = x.RegnNumber,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            EstablishedYear = x.EstablishedYear,
            Website = x.Website,
            BusinessTypeId = x.BusinessTypeId,
            CategoryId = x.CategoryId,
            BusinessTypeName = x.BusinessType?.Name,
            CategoryName = x.Category?.Name,
            Description = x.Description,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return companyList;
    }
}
