using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Application.Services;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Queries.GetConsumerByName;

internal class GetConsumerByNameQueryHandler : IRequestHandler<GetConsumerByNameQuery, ConsumerDto>
{
    private readonly IConsumerService _consumerService;

    public GetConsumerByNameQueryHandler(IConsumerService consumerService) =>
        _consumerService = consumerService;

    public async Task<ConsumerDto> Handle(GetConsumerByNameQuery request, CancellationToken cancellationToken)
    {
        var consumer = await _consumerService.GetByConsumerNameAsync(request.ConsumerName);
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
