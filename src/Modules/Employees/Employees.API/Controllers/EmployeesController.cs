namespace Employees.API;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    readonly IMediator _mediator;
    public EmployeesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Employee> employees = await _mediator.Send(new GetEmployeeQuery());

        if (ModelState.IsValid)
            return Ok(employees);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Employee employee = await _mediator.Send(new GetEmployeeByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(employee);

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Employee employee)
    {
        Employee employeeCreated = await _mediator.Send(new AddEmployeeCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeCreated);

        return BadRequest();
    }

    [HttpPost("Bulk")]
    public async Task<IActionResult> Post(IEnumerable<Employee> employees)
    {
        IEnumerable<Employee> employeesCreated = await _mediator.Send(new AddEmployeesCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesCreated);

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Employee employee)
    {
        Employee employeeUpdated = await _mediator.Send(new UpdateEmployeeCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeUpdated);

        return BadRequest();
    }

    [HttpPut("Bulk")]
    public async Task<IActionResult> Put(IEnumerable<Employee> employees)
    {
        IEnumerable<Employee> employeesUpdated = await _mediator.Send(new UpdateEmployeesCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesUpdated);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteEmployeeByIdCommand(id));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Employee employee)
    {
        await _mediator.Send(new DeleteEmployeeCommand(employee));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete("Bulk")]
    public async Task<IActionResult> Delete(IEnumerable<Employee> employees)
    {
        await _mediator.Send(new DeleteEmployeesCommand(employees));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }
}