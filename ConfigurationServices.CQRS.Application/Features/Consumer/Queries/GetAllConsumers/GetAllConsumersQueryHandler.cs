using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Queries.GetAllConsumers;

internal class GetAllConsumersQueryHandler : IRequestHandler<GetAllConsumersQuery, IEnumerable<ConsumerDto>>
{
    private readonly IGenericRepository<Consumer> _consumerRepository;

    public GetAllConsumersQueryHandler(
        IGenericRepository<Consumer> consumerRepository) =>
        _consumerRepository = consumerRepository;

    public async Task<IEnumerable<ConsumerDto>> Handle(GetAllConsumersQuery request, CancellationToken cancellationToken)
    {
        var consumer = await _consumerRepository.GetAllAsync();

        var consumers = consumer.Select(x => new ConsumerDto
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Password = x.Password,
            PlanTypeId = x.PlanTypeId,
            PlanTypeName = x.PlanType?.Name,
            PhoneNumber = x.PhoneNumber,
            Website = x.Website,
            Description = x.Description,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive,
        }).ToList();

        return consumers;
    }
}
