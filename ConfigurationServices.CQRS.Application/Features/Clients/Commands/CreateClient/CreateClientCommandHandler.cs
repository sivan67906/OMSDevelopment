using MediatR;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;

namespace ConfigurationServices.CQRS.Application.Feauters.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IGenericRepository<Client> _repository;
        public CreateClientCommandHandler(IGenericRepository<Client> repository) => _repository = repository;

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                ClientName = request.ClientName,
                ClientCode = request.ClientCode,
                Description = request.Description,
                Email = request.Email,
                CompanyId = request.CompanyId,
                PhoneNumber = request.PhoneNumber,
               
                    Address1 = request.Address1,
                    Address2 = request.Address2,
                
                CountryId = request.CountryId,
                StateId = request.StateId,
                CityId = request.CityId,
                ZipCode = request.ZipCode,
            };  
            await _repository.CreateAsync(client);
            return client.Id;
        }
    }
}


