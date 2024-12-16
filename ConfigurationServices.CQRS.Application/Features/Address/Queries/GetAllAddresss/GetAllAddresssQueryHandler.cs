using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Queries.GetAllAddresses;

internal class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<AddressDto>>
{
    private readonly IGenericRepository<AddressDto> _addressRepository;

    public GetAllAddressesQueryHandler(
        IGenericRepository<AddressDto> addressRepository) =>
        _addressRepository = addressRepository;

    public async Task<IEnumerable<AddressDto>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _addressRepository.GetAllAsync();

        var addressList = companies.Select(x => new AddressDto
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












