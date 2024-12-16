using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Commands.DeleteConsumer;

internal class DeleteConsumerCommandHandler : IRequestHandler<DeleteConsumerCommand>
{
    private readonly IGenericRepository<Consumer> _consumerRepository;

    public DeleteConsumerCommandHandler(
        IGenericRepository<Consumer> consumerRepository) =>
        _consumerRepository = consumerRepository;
    public async Task Handle(DeleteConsumerCommand request, CancellationToken cancellationToken)
    {
        var consumer = new Consumer
        {
            Id = request.Id
        };

        await _consumerRepository.DeleteAsync(consumer);
    }
}
