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
        IEnumerable<Customer> customers = await _mediator.Send(new GetCustomerQuery());

        if (ModelState.IsValid)
            return Ok(customers);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Customer customer = await _mediator.Send(new GetCustomerByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(customer);

        return BadRequest();
    }
}
