using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Commands.DeleteSearchConsumer;

internal class DeleteSearchConsumerCommandHandler : IRequestHandler<DeleteSearchConsumerCommand>
{
    private readonly IGenericRepository<Consumer> _consumerRepository;

    public DeleteSearchConsumerCommandHandler(
        IGenericRepository<Consumer> consumerRepository) =>
        _consumerRepository = consumerRepository;
    public async Task Handle(DeleteSearchConsumerCommand request, CancellationToken cancellationToken)
    {
        await _consumerRepository.DeleteAsync(request.Id);
    }
}
