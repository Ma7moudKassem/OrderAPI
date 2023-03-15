namespace Customers.API;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    readonly IMediator _mediator;
    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Customer> customers = await _mediator.Send(new GetCustomerQuery());

        if (ModelState.IsValid)
            return Ok(customers);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Customer customer = await _mediator.Send(new GetCustomerByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(customer);

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Customer customer)
    {
        Customer customerCreated = await _mediator.Send(new AddCustomerCommand(customer));


        if (ModelState.IsValid)
            return Ok(customerCreated);

        return BadRequest();
    }

    [HttpPost("Bulk")]
    public async Task<IActionResult> Post(IEnumerable<Customer> customers)
    {
        IEnumerable<Customer> customersCreated = await _mediator.Send(new AddCustomersCommand(customers));

        if (ModelState.IsValid)
            return Ok(customersCreated);

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Customer customer)
    {
        Customer customerUpdated = await _mediator.Send(new UpdateCustomerCommand(customer));

        if (ModelState.IsValid)
            return Ok(customerUpdated);

        return BadRequest();
    }

    [HttpPut("Bulk")]
    public async Task<IActionResult> Put(IEnumerable<Customer> customers)
    {
        IEnumerable<Customer> customersUpdated = await _mediator.Send(new UpdateCustomersCommand(customers));

        if (ModelState.IsValid)
            return Ok(customersUpdated);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteCustomerByIdCommand(id));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Customer customer)
    {
        await _mediator.Send(new DeleteCustomerCommand(customer));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete("Bulk")]
    public async Task<IActionResult> Delete(IEnumerable<Customer> customers)
    {
        await _mediator.Send(new DeleteCustomersCommand(customers));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }
}
