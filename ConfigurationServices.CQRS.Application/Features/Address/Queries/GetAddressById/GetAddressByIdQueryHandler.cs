using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Queries.GetAddressById;

internal class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
{
    private readonly IGenericRepository<AddressDto> _addressRepository;

    public GetAddressByIdQueryHandler(
        IGenericRepository<AddressDto> addressRepository) =>
        _addressRepository = addressRepository;

    public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.GetByIdAsync(request.Id);
        if (address == null) return null;
        return new AddressDto
        {
        };
    }
}












