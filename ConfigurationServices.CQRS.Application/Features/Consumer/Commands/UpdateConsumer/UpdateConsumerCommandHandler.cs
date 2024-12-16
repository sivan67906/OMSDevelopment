using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Commands.UpdateConsumer;

internal class UpdateConsumerCommandHandler : IRequestHandler<UpdateConsumerCommand>
{
    private readonly IGenericRepository<Consumer> _consumerRepository;

    public UpdateConsumerCommandHandler(
        IGenericRepository<Consumer> consumerRepository) =>
        _consumerRepository = consumerRepository;

    public async Task Handle(UpdateConsumerCommand request, CancellationToken cancellationToken)
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
            UpdatedDate = DateTime.Now,
            IsActive = request.IsActive
        };

        await _consumerRepository.UpdateAsync(consumer);
    }
}
