using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.States.Commands.UpdateState;

internal class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand>
{
    private readonly IGenericRepository<State> _stateRepository;

    public UpdateStateCommandHandler(
        IGenericRepository<State> stateRepository) =>
        _stateRepository = stateRepository;

    public async Task Handle(UpdateStateCommand request, CancellationToken cancellationToken)
    {
        var state = new State
        {
        };

        await _stateRepository.UpdateAsync(state);
    }
}












