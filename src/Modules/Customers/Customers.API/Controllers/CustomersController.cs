using MediatR;

namespace Customers.API;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    IMediator _mediator;
    public CustomersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetCustomerQuery());

        if (ModelState.IsValid)
            return Ok(result);

        return BadRequest();
    }
}
