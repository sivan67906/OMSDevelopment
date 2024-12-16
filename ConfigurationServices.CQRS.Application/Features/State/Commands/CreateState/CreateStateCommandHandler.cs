using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.States.Commands.CreateState;

internal class CreateStateCommandHandler(
    IGenericRepository<State> stateRepository) : IRequestHandler<CreateStateCommand>
{
    public async Task Handle(CreateStateCommand request, CancellationToken cancellationToken)
    {
        var state = new State
        {

        };

        await stateRepository.CreateAsync(state);
    }
}












