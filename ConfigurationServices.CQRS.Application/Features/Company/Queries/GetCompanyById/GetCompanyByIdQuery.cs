using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQuery : IRequest<CompanyDto>
    {
        public int Id { get; set; }
    }
}
