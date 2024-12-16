using ConfigurationServices.CQRS.Application.DTOs;
using ConfigurationServices.CQRS.Domain.Entities;
using ConfigurationServices.CQRS.Domain.Interfaces;
using MediatR;

namespace ConfigurationServices.CQRS.Application.Features.States.Queries.GetStateById;

internal class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, StateDTO>
{
    private readonly IGenericRepository<State> _stateRepository;

    public GetStateByIdQueryHandler(
        IGenericRepository<State> stateRepository) =>
        _stateRepository = stateRepository;

    public async Task<StateDTO> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
    {
        var state = await _stateRepository.GetByIdAsync(request.Id);
        if (state == null) return null;
        return new StateDTO
        {
        };
    }
}












