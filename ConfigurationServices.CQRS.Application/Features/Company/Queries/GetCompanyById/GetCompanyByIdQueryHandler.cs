﻿using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Companies.Queries.GetCompanyById;

internal class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDTO>
{
    private readonly IGenericRepository<Company> _companyRepository;

    public GetCompanyByIdQueryHandler(
        IGenericRepository<Company> companyRepository) =>
        _companyRepository = companyRepository;

    public async Task<CompanyDTO> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.Id);
        if (company == null) return null;
        return new CompanyDTO
        {
            Id = company.Id,
            Name = company.Name,
            RegnNumber = company.RegnNumber,
            Email = company.Email,
            PhoneNumber = company.PhoneNumber,
            EstablishedYear = company.EstablishedYear,
            Website = company.Website,
            BusinessTypeId = company.BusinessTypeId,
            CategoryId = company.CategoryId,
            Description = company.Description,
            CreatedDate = company.CreatedDate,
            UpdatedDate = company.UpdatedDate,
            IsActive = company.IsActive
        };
    }
}
