using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumerById;

internal class GetSearchConsumerByIdQueryHandler : IRequestHandler<GetSearchConsumerByIdQuery, ConsumerDto>
{
    private readonly IGenericRepository<Consumer> _consumerRepository;

    public GetSearchConsumerByIdQueryHandler(
        IGenericRepository<Consumer> consumerRepository) =>
        _consumerRepository = consumerRepository;

    public async Task<ConsumerDto> Handle(GetSearchConsumerByIdQuery request, CancellationToken cancellationToken)
    {
        var consumer = await _consumerRepository.GetByIdAsync(request.Id);
        if (consumer == null) return null;
        return new ConsumerDto
        {
            Id = consumer.Id,
            FirstName = consumer.FirstName,
            LastName = consumer.LastName,
            Email = consumer.Email,
            Password = consumer.Password,
            PlanTypeId = consumer.PlanTypeId,
            PhoneNumber = consumer.PhoneNumber,
            Website = consumer.Website,
            Description = consumer.Description,
            CreatedDate = consumer.CreatedDate,
            UpdatedDate = consumer.UpdatedDate,
            IsActive = consumer.IsActive
        };
    }
}
