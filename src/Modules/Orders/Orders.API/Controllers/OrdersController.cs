using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Orders.API;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    readonly IMediator _mediator;
    public OrdersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Order> orders = await _mediator.Send(new GetOrderQuery());

        if (ModelState.IsValid)
            return Ok(orders);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Order order = await _mediator.Send(new GetOrderByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(order);

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Order order)
    {
        Order orderCreated = await _mediator.Send(new AddOrderCommand(order));

        if (ModelState.IsValid)
            return Ok(orderCreated);

        return BadRequest();
    }

    [HttpPost("Bulk")]
    public async Task<IActionResult> Post(IEnumerable<Order> orders)
    {
        IEnumerable<Order> ordersCreated = await _mediator.Send(new AddOrdersCommand(orders));

        if (ModelState.IsValid)
            return Ok(ordersCreated);

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Order order)
    {
        Order orderUpdated = await _mediator.Send(new UpdateOrderCommand(order));

        if (ModelState.IsValid)
            return Ok(orderUpdated);

        return BadRequest();
    }

    [HttpPut("Bulk")]
    public async Task<IActionResult> Put(IEnumerable<Order> orders)
    {
        IEnumerable<Order> ordersUpdated = await _mediator.Send(new UpdateOrdersCommand(orders));

        if (ModelState.IsValid)
            return Ok(ordersUpdated);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteOrderByIdCommand(id));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Order order)
    {
        await _mediator.Send(new DeleteOrderCommand(order));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete("Bulk")]
    public async Task<IActionResult> Delete(IEnumerable<Order> orders)
    {
        await _mediator.Send(new DeleteOrdersCommand(orders));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }
}
