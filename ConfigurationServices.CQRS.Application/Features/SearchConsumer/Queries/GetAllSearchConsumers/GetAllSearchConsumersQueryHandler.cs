using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetAllSearchConsumers;

internal class GetAllSearchConsumersQueryHandler : IRequestHandler<GetAllSearchConsumersQuery, IEnumerable<ConsumerDto>>
{
    private readonly IGenericRepository<Consumer> _consumerRepository;

    public GetAllSearchConsumersQueryHandler(
        IGenericRepository<Consumer> consumerRepository) =>
        _consumerRepository = consumerRepository;

    public async Task<IEnumerable<ConsumerDto>> Handle(GetAllSearchConsumersQuery request, CancellationToken cancellationToken)
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
            PhoneNumber = x.PhoneNumber,
            Website = x.Website,
            Description = x.Description,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            IsActive = x.IsActive
        }).ToList();

        return consumers;
    }
}
