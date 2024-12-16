﻿using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.SearchConsumers.Queries.GetSearchConsumerByDateBetween
{
    public class GetSearchConsumerByDateBetweenQuery : IRequest<IEnumerable<ConsumerDto>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}