using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest
    {
        public int Id { get; set; }
    }
}












