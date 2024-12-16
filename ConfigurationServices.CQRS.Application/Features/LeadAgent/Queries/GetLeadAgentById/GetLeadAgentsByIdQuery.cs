using MediatR;
using ConfigurationServices.CQRS.Application.DTOs;

namespace ConfigurationServices.CQRS.Application.Feauters.LeadAgent.Queries.GetLeadAgentById
{
    public class GetLeadAgentsByIdQuery : IRequest<LeadAgentDTO>
    {
        public int Id { get; set; }
    }
}


