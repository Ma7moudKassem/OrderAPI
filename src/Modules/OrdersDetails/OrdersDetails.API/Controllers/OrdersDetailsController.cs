namespace OrdersDetails.API;

[ApiController]
[Route("api/[controller]")]
public class OrdersDetailsController : ControllerBase
{
    readonly IMediator _mediator;
    public OrdersDetailsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<OrdersDetail> employees = await _mediator.Send(new GetOrdersDetailQuery());

        if (ModelState.IsValid)
            return Ok(employees);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        OrdersDetail employee = await _mediator.Send(new GetOrdersDetailByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(employee);

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(OrdersDetail employee)
    {
        OrdersDetail employeeCreated = await _mediator.Send(new AddOrdersDetailCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeCreated);

        return BadRequest();
    }

    [HttpPost("Bulk")]
    public async Task<IActionResult> Post(IEnumerable<OrdersDetail> employees)
    {
        IEnumerable<OrdersDetail> employeesCreated = await _mediator.Send(new AddOrdersDetailsCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesCreated);

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(OrdersDetail employee)
    {
        OrdersDetail employeeUpdated = await _mediator.Send(new UpdateOrdersDetailCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeUpdated);

        return BadRequest();
    }

    [HttpPut("Bulk")]
    public async Task<IActionResult> Put(IEnumerable<OrdersDetail> employees)
    {
        IEnumerable<OrdersDetail> employeesUpdated = await _mediator.Send(new UpdateOrdersDetailsCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesUpdated);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteOrdersDetailByIdCommand(id));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(OrdersDetail employee)
    {
        await _mediator.Send(new DeleteOrdersDetailCommand(employee));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete("Bulk")]
    public async Task<IActionResult> Delete(IEnumerable<OrdersDetail> employees)
    {
        await _mediator.Send(new DeleteOrdersDetailsCommand(employees));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }
}