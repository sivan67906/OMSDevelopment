﻿using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Application.Services;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumersByName;

internal class GetSearchConsumersByNameQueryHandler : IRequestHandler<GetSearchConsumersByNameQuery, IEnumerable<ConsumerDto>>
{
    private readonly IConsumerService _consumerService;

    public GetSearchConsumersByNameQueryHandler(IConsumerService consumerService) =>
        _consumerService = consumerService;

    public async Task<IEnumerable<ConsumerDto>> Handle(GetSearchConsumersByNameQuery request, CancellationToken cancellationToken)
    {
        var consumers = await _consumerService.SearchConsumersByNameAsync(request.ConsumerName);
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
