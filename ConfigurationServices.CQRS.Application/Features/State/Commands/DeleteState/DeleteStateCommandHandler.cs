using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.States.Commands.DeleteState;

internal class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand>
{
    private readonly IGenericRepository<State> _stateRepository;

    public DeleteStateCommandHandler(
        IGenericRepository<State> stateRepository) =>
        _stateRepository = stateRepository;
    public async Task Handle(DeleteStateCommand request, CancellationToken cancellationToken)
    {
        await _stateRepository.DeleteAsync(request.Id);
    }
}












