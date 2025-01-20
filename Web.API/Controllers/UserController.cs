using Application.DTOs.Requests;
using Application.User.Commands.CreateUser;
using Application.User.Commands.UpdateUser;
using Domain.Entities;
using Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Web.API.Controllers;

[Route("user")]
public class UserController(BankContext context, IMediator mediator, ILogger<UserController> logger): ControllerBase
{
    private readonly BankContext _context = context;
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<UserController> _logger = logger;

    /// <summary>
    ///     Create a new user
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("create")]
    [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
    [Produces("application/json")]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserCommand request,
        CancellationToken cancellationToken
    )
    {
        Guid response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    ///     Update a user
    /// </summary>
    /// <remarks>Awesomeness!</remarks>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The modified user</returns>
    /// <response code="200">User updated</response> 
    [HttpPut("update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<IActionResult> UpdateUser(
        [FromRoute] Guid id,
        [FromBody] UpdateUserReqDto request,
        CancellationToken cancellationToken
    )
    {
        User response = await _mediator.Send(new UpdateUserCommand(request.Name, id), cancellationToken);
        return Ok(response);
    }

    [HttpGet("test/{id}")]
    public IActionResult Test([FromRoute] int id)
    {
        _logger.LogInformation("Test log!!!!!, {a}", id);
        return Ok();
    }
}
