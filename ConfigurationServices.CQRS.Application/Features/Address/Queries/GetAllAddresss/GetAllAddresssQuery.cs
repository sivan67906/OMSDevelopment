using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesQuery : IRequest<IEnumerable<AddressDTO>>
{
}












