using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Service.Cap7.Boundaries;
using Web.Service.Cap7.Mappers;
using Web.Service.Cap7.Requests;
using Web.Service.Cap7.Services;
using Web.Service.Cap7.UseCases.GetAllSectorsUseCase.Boundaries;
using Web.Service.Cap7.UseCases.GetSectorByIdUseCase.Boundaries;

namespace Web.Service.Cap7.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SectorController(
    IMediator mediator    
) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var input = new GetSectorByIdInput(id, UserId);

        var result = await _mediator.Send(input, cancellationToken);

        if (!result.IsValid)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var input = new GetAllSectorsInput(UserId);

        var result = await _mediator.Send(input, cancellationToken);

        if (!result.IsValid)
            return NotFound(result);

        return Ok(result);
    }

    [MapToApiVersion(1)]
    [HttpPost]
    [ProducesResponseType(typeof(Output), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Output), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] NewSectorRequest request, CancellationToken cancellationToken)
    {
        var input = request.MapToInput(UserId);

        var output = await _mediator.Send(input, cancellationToken);

        if (!output.IsValid)
            return BadRequest(output);

        return Created();
    }
}
