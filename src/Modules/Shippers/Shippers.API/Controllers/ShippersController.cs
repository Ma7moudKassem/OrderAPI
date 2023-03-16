namespace Shippers.API;

[ApiController]
[Route("api/[controller]")]
public class ShippersController : ControllerBase
{
    readonly IMediator _mediator;
    public ShippersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Shipper> employees = await _mediator.Send(new GetShipperQuery());

        if (ModelState.IsValid)
            return Ok(employees);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Shipper employee = await _mediator.Send(new GetShipperByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(employee);

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Shipper employee)
    {
        Shipper employeeCreated = await _mediator.Send(new AddShipperCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeCreated);

        return BadRequest();
    }

    [HttpPost("Bulk")]
    public async Task<IActionResult> Post(IEnumerable<Shipper> employees)
    {
        IEnumerable<Shipper> employeesCreated = await _mediator.Send(new AddShippersCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesCreated);

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Shipper employee)
    {
        Shipper employeeUpdated = await _mediator.Send(new UpdateShipperCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeUpdated);

        return BadRequest();
    }

    [HttpPut("Bulk")]
    public async Task<IActionResult> Put(IEnumerable<Shipper> employees)
    {
        IEnumerable<Shipper> employeesUpdated = await _mediator.Send(new UpdateShippersCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesUpdated);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteShipperByIdCommand(id));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Shipper employee)
    {
        await _mediator.Send(new DeleteShipperCommand(employee));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete("Bulk")]
    public async Task<IActionResult> Delete(IEnumerable<Shipper> employees)
    {
        await _mediator.Send(new DeleteShippersCommand(employees));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }
}