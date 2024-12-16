using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Application.Services;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Queries.GetConsumersBySearch;

internal class GetConsumersBySearchQueryHandler : IRequestHandler<GetConsumersBySearchQuery, IEnumerable<ConsumerDto>>
{
    private readonly IConsumerService _consumerService;

    public GetConsumersBySearchQueryHandler(IConsumerService consumerService) =>
       _consumerService = consumerService;

    public async Task<IEnumerable<ConsumerDto>> Handle(GetConsumersBySearchQuery request, CancellationToken cancellationToken)
    {
        var consumer = await _consumerService.SearchConsumersByNameAsync(request.ConsumerName);
        if (consumer == null || !consumer.Any()) return null;

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
