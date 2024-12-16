using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Commands.CreateAddress;

internal class CreateAddressCommandHandler(
    IGenericRepository<AddressDTO> addressRepository) : IRequestHandler<CreateAddressCommand>
{
    public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = new AddressDTO
        {

        };

        await addressRepository.CreateAsync(address);
    }
}












