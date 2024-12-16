using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;

namespace ConfigurationServices.CQRS.Application.Feauters.Clients.Queries.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDTO>>
    {
        private readonly IGenericRepository<Client> _repository;
        public GetAllClientsQueryHandler(IGenericRepository<Client> repository) => _repository = repository;

        public async Task<IEnumerable<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _repository.GetAllAsync();

            var clientlist = clients.Select(x => new ClientDTO
            {
                Id = x.Id,
                ClientName = x.ClientName,
                ClientCode = x.ClientCode,
                Description = x.Description,
                Email = x.Email,
                CompanyId = x.CompanyId,
                PhoneNumber = x.PhoneNumber,
                Address1 = request.Address1,
                Address2 = request.Address2,
                CountryId = x.CountryId,
                StateId = x.StateId,
                CityId = x.CityId,
                ZipCode = x.ZipCode,
            }).ToList();

            return clientlist;
        }
    }
}


