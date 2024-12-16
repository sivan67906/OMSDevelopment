using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Queries.GetAllCountries;

public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDto>>
{
}












