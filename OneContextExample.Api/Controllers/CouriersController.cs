using Mediator;
using Microsoft.AspNetCore.Mvc;
using OneContextExample.Api.Requests;
using OneContextExample.Couriers.Application.Commands;
using OneContextExample.Couriers.Application.Queries;

namespace OneContextExample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouriersController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCouriersQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [Route("{id}/take-order")]
    public async Task<IActionResult> TakeOrder(
        Guid id,
        [FromBody] TakeOrderRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new TakeOrderCommand(id, request.orderId), cancellationToken);
        return result ? Ok() : BadRequest("Could not take order");
    }
}