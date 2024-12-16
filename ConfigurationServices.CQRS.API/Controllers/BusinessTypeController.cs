using ConfigurationServices.CQRS.Application.Features.BusinessTypes.Commands.CreateBusinessType;
using ConfigurationServices.CQRS.Application.Features.BusinessTypes.Commands.DeleteBusinessType;
using ConfigurationServices.CQRS.Application.Features.BusinessTypes.Commands.UpdateBusinessType;
using ConfigurationServices.CQRS.Application.Features.BusinessTypes.Queries.GetAllBusinessTypes;
using ConfigurationServices.CQRS.Application.Features.BusinessTypes.Queries.GetBusinessTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationServices.CQRS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    public BusinessTypeController(IMediator mediator) => _mediator = mediator;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var businessTypeList = await _mediator.Send(new GetAllBusinessTypesQuery());
        return Ok(businessTypeList);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int Id)
    {
        var businessType = await _mediator.Send(new GetBusinessTypeByIdQuery { Id = Id });
        if (businessType is not null) { return Ok(businessType); }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateBusinessTypeCommand command)
    {
        await _mediator.Send(command);
        return Ok("BusinessType Created Successfully.");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateBusinessTypeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(DeleteBusinessTypeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}


