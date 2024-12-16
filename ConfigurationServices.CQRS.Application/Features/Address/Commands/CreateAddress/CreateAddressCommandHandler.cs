using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Commands.CreateAddress;

internal class CreateAddressCommandHandler(
    IGenericRepository<AddressDto> addressRepository) : IRequestHandler<CreateAddressCommand>
{
    public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = new AddressDto
        {

        };

        await addressRepository.CreateAsync(address);
    }
}












