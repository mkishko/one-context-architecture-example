using Mediator;
using Microsoft.AspNetCore.Mvc;
using OneContextExample.Orders.Contracts.Queries;

namespace OneContextExample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(ISender mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves the details of a specific order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to retrieve.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IActionResult"/>:
    /// 200 OK with the order details if the order is found, or 404 Not Found if the order does not exist.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([
        FromRoute] Guid id, 
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetOrderQuery(id), cancellationToken);
        
        if (result == null)
            return NotFound();

        return Ok(result);
    }
}