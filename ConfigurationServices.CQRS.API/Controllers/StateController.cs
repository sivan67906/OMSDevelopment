using ConfigurationServices.CQRS.Application.Features.States.Commands.CreateState;
using ConfigurationServices.CQRS.Application.Features.States.Commands.DeleteState;
using ConfigurationServices.CQRS.Application.Features.States.Commands.UpdateState;
using ConfigurationServices.CQRS.Application.Features.States.Queries.GetAllStates;
using ConfigurationServices.CQRS.Application.Features.States.Queries.GetStateById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationServices.CQRS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IMediator _mediator;
    public StateController(IMediator mediator) => _mediator = mediator;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var stateList = await _mediator.Send(new GetAllStatesQuery());
        return Ok(stateList);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int Id)
    {
        var state = await _mediator.Send(new GetStateByIdQuery { Id = Id });
        if (state is not null) { return Ok(state); }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateStateCommand command)
    {
        await _mediator.Send(command);
        return Ok("State Created Successfully.");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateStateCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int Id)
    {
        await _mediator.Send(new DeleteStateCommand { Id = Id });
        return NoContent();
    }
}






