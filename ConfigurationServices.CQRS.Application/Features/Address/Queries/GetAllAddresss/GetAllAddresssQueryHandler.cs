using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Queries.GetAllAddresses;

internal class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressDTO>>
{
    private readonly IGenericRepository<AddressDTO> _addressRepository;

    public GetAllAddressesQueryHandler(
        IGenericRepository<AddressDTO> addressRepository) =>
        _addressRepository = addressRepository;

    public async Task<IEnumerable<AddressDTO>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _addressRepository.GetAllAsync();

        var addressList = companies.Select(x => new AddressDTO
        {
            Id = x.Id,
            Name = x.Name,
            Code = x.Code,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return addressList;
    }
}












