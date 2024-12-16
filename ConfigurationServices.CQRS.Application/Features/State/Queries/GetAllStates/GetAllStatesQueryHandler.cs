using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.States.Queries.GetAllStates;

internal class GetAllStatesQueryHandler : IRequestHandler<GetAllStatesQuery, IEnumerable<StateDTO>>
{
    private readonly IGenericRepository<State> _stateRepository;

    public GetAllStatesQueryHandler(
        IGenericRepository<State> stateRepository) =>
        _stateRepository = stateRepository;

    public async Task<IEnumerable<StateDTO>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _stateRepository.GetAllAsync();

        var stateList = companies.Select(x => new StateDTO
        {

        }).ToList();

        return stateList;
    }
}












