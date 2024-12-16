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
        var consumer = new Consumer
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            PlanTypeId = request.PlanTypeId,
            PhoneNumber = request.PhoneNumber,
            Website = request.Website,
            Description = request.Description,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsActive = request.IsActive
        };

        //await _consumerRepository.DeleteAsync(consumer);
    }
}
