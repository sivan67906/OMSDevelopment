using ConfigurationServices.CQRS.Domain.Entities;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.BusinessTypes.Queries.GetAllBusinessTypes;

public class GetAllBusinessTypesQuery : IRequest<IEnumerable<BusinessTypeDTO>>
{
}





