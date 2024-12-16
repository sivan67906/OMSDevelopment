using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Commands.UpdateAddress;

internal class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IGenericRepository<AddressDto> _addressRepository;

    public UpdateAddressCommandHandler(
        IGenericRepository<AddressDto> addressRepository) =>
        _addressRepository = addressRepository;

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = new AddressDto
        {
        };

        await _addressRepository.UpdateAsync(address);
    }
}












