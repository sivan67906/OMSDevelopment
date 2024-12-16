using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQuery : IRequest<IEnumerable<CompanyDTO>>
{
}
