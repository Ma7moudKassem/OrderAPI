namespace Suppliers.API;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    readonly IMediator _mediator;
    public SuppliersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Supplier> employees = await _mediator.Send(new GetSupplierQuery());

        if (ModelState.IsValid)
            return Ok(employees);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Supplier employee = await _mediator.Send(new GetSupplierByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(employee);

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Supplier employee)
    {
        Supplier employeeCreated = await _mediator.Send(new AddSupplierCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeCreated);

        return BadRequest();
    }

    [HttpPost("Bulk")]
    public async Task<IActionResult> Post(IEnumerable<Supplier> employees)
    {
        IEnumerable<Supplier> employeesCreated = await _mediator.Send(new AddSuppliersCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesCreated);

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Supplier employee)
    {
        Supplier employeeUpdated = await _mediator.Send(new UpdateSupplierCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeUpdated);

        return BadRequest();
    }

    [HttpPut("Bulk")]
    public async Task<IActionResult> Put(IEnumerable<Supplier> employees)
    {
        IEnumerable<Supplier> employeesUpdated = await _mediator.Send(new UpdateSuppliersCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesUpdated);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteSupplierByIdCommand(id));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Supplier employee)
    {
        await _mediator.Send(new DeleteSupplierCommand(employee));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete("Bulk")]
    public async Task<IActionResult> Delete(IEnumerable<Supplier> employees)
    {
        await _mediator.Send(new DeleteSuppliersCommand(employees));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }
}