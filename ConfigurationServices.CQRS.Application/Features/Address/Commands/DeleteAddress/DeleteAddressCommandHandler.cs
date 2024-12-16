using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Commands.DeleteAddress;

internal class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IGenericRepository<AddressDTO> _addressRepository;

    public DeleteAddressCommandHandler(
        IGenericRepository<AddressDTO> addressRepository) =>
        _addressRepository = addressRepository;
    public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        await _addressRepository.DeleteAsync(request.Id);
    }
}












