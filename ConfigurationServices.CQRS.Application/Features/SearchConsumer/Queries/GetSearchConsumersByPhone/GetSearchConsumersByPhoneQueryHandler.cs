﻿using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Application.Services;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumersByPhone;

internal class GetSearchConsumersByPhoneQueryHandler : IRequestHandler<GetSearchConsumersByPhoneQuery, IEnumerable<ConsumerDTO>>
{
    private readonly IConsumerService _consumerService;

    public GetSearchConsumersByPhoneQueryHandler(IConsumerService consumerService) =>
        _consumerService = consumerService;

    public async Task<IEnumerable<ConsumerDTO>> Handle(GetSearchConsumersByPhoneQuery request, CancellationToken cancellationToken)
    {
        var consumers = await _consumerService.SearchConsumersByPhoneAsync(request.PhoneNumber);
        if (consumers == null) return null;
        var consumerList = consumers.Select(x => new ConsumerDTO
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
