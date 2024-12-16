﻿using ConfigurationServices.CQRS.Application.DTOs;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.Consumers.Queries.GetConsumerById
{
    public class GetCompanyByIdQuery : IRequest<ConsumerDto>
    {
        public int Id { get; set; }
    }
}