using ConfigurationServices.CQRS.Domain.Entities;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Queries.GetCountryById
{
    public class GetCountryByIdQuery : IRequest<CountryDTO>
    {
        public int Id { get; set; }
    }
}












