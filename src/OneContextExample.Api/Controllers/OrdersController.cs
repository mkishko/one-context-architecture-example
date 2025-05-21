using Mediator;
using Microsoft.AspNetCore.Mvc;
using OneContextExample.Orders.Contracts.Queries;

namespace OneContextExample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(ISender mediator) : ControllerBase
{
    /// <summary>
    /// Gets an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// Returns the order if found, otherwise returns a 404 Not Found response.
    /// </returns>
    /// <response code="200">Returns the requested order.</response>
    /// <response code="404">If the order is not found.</response>
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