using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Application.Services;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumersByPhone;

internal class GetSearchConsumersByPhoneQueryHandler : IRequestHandler<GetSearchConsumersByPhoneQuery, IEnumerable<ConsumerDto>>
{
    private readonly IConsumerService _consumerService;

    public GetSearchConsumersByPhoneQueryHandler(IConsumerService consumerService) =>
        _consumerService = consumerService;

    public async Task<IEnumerable<ConsumerDto>> Handle(GetSearchConsumersByPhoneQuery request, CancellationToken cancellationToken)
    {
        var consumers = await _consumerService.SearchConsumersByPhoneAsync(request.PhoneNumber);
        if (consumers == null) return null;
        var consumerList = consumers.Select(x => new ConsumerDto
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

        return consumerList;
    }
}
