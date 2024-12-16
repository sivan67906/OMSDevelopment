using ConfigurationServices.CQRS.Domain.Entities;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Queries.GetAllCountries;

public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDTO>>
{
}












