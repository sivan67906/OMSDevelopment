using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest
    {
        public int Id { get; set; }
    }
}












