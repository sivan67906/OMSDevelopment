using ConfigurationServices.CQRS.Application.Features.Companies.Commands.DeleteCompany;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Companys.Commands.DeleteCompany;

internal class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly IGenericRepository<Company> _companyRepository;

    public DeleteCompanyCommandHandler(
        IGenericRepository<Company> companyRepository) =>
        _companyRepository = companyRepository;
    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        await _companyRepository.DeleteAsync(request.Id);
    }
}
