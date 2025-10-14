using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.Requests;
using Web.Service.Cap7.UseCases.ActivateEquipmentUseCase.Boundaries;

namespace Web.Service.Cap7.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class EquipmentController(
    IMediator mediator    
) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] NewEquipmentRequest request, CancellationToken cancellationToken)
    {
        var input = request.MapToInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);
        
        if (!output.IsValid)
            return BadRequest(output);

        return Created();
    }

    [HttpPost("{id:int}/activate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ActivateAsync([Required] int id, CancellationToken cancellationToken)
    {
        var input = new ActivateEquipmentInput(id, UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if (!output.IsValid)
            return BadRequest(output);

        return Ok(output.Result);
    }
}
