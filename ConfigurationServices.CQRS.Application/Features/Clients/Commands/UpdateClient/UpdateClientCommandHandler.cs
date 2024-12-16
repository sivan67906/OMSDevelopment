using MediatR;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;

namespace ConfigurationServices.CQRS.Application.Feauters.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, int>
    {
        private readonly IGenericRepository<Client> _repository;
        public UpdateClientCommandHandler(IGenericRepository<Client> repository) => _repository = repository;

        public async Task<int> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var product = new Client
            {
                Id = request.Id,
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
                ZipCode = request.ZipCode
            };
            await _repository.UpdateAsync(product);
            return request.Id;
        }
    }
}


