using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThreeAmigos.Services.Orders.API.Operations.AddToBasket;
using ThreeAmigos.Services.Orders.API.Operations.CompleteOrder;

namespace ThreeAmigos.Services.Orders.API.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v1.0/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IMediator _mediator;

    public OrdersController(ILogger<OrdersController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> AddToBasket()
    {
        _logger.LogInformation("Controller - adding to basket...");

        await _mediator.Send(new AddToBasket.Command());
        
        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> CompleteOrder()
    {
        _logger.LogInformation("Controller - completing order...");

        await _mediator.Send(new CompleteOrder.Command());
        
        return Ok();
    }
}