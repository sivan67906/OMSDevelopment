using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Commands.UpdateAddress;

internal class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IGenericRepository<AddressDTO> _addressRepository;

    public UpdateAddressCommandHandler(
        IGenericRepository<AddressDTO> addressRepository) =>
        _addressRepository = addressRepository;

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = new AddressDTO
        {
        };

        await _addressRepository.UpdateAsync(address);
    }
}












