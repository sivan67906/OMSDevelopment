using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Companies.Commands.UpdateCompany;

internal class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IGenericRepository<Company> _companyRepository;

    public UpdateCompanyCommandHandler(
        IGenericRepository<Company> companyRepository) =>
        _companyRepository = companyRepository;

    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company
        {
            Id = request.Id,
            Name = request.Name,
            RegnNumber = request.RegnNumber,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            EstablishedYear = request.EstablishedYear,
            Website = request.Website,
            BusinessTypeId = request.BusinessTypeId,
            CategoryId = request.CategoryId,
            Description = request.Description,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsActive = request.IsActive
        };

        await _companyRepository.UpdateAsync(company);
    }
}
