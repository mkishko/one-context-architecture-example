using Mediator;
using Microsoft.AspNetCore.Mvc;
using OneContextExample.Api.Requests;
using OneContextExample.Couriers.Contracts.Commands;
using OneContextExample.Couriers.Contracts.Queries;

namespace OneContextExample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouriersController(ISender mediator) : ControllerBase
{
    /// <summary>
    /// Gets a list of all couriers.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// Returns a list of all couriers.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCouriersQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Takes an order for a courier.
    /// </summary>
    /// <param name="id">The ID of the courier.</param>
    /// <param name="request">The request containing the order ID to take.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// Returns 200 OK if the order was successfully taken, or 400 Bad Request if the order cannot be taken.
    /// </returns>
    /// <response code="400">The order cannot be taken because it has already been taken or is in an invalid state.</response>
    [HttpPost("{id}/take-order")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> TakeOrder(
        Guid id,
        [FromBody] TakeOrderRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new TakeOrderCommand(id, request.orderId), cancellationToken);
        return result ? Ok() : BadRequest("Order cannot be taken");
    }
}