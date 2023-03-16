namespace Categories.API;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    readonly IMediator _mediator;
    public CategoriesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Category> employees = await _mediator.Send(new GetCategoryQuery());

        if (ModelState.IsValid)
            return Ok(employees);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Category employee = await _mediator.Send(new GetCategoryByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(employee);

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Category employee)
    {
        Category employeeCreated = await _mediator.Send(new AddCategoryCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeCreated);

        return BadRequest();
    }

    [HttpPost("Bulk")]
    public async Task<IActionResult> Post(IEnumerable<Category> employees)
    {
        IEnumerable<Category> employeesCreated = await _mediator.Send(new AddCategoriesCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesCreated);

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Category employee)
    {
        Category employeeUpdated = await _mediator.Send(new UpdateCategoryCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeUpdated);

        return BadRequest();
    }

    [HttpPut("Bulk")]
    public async Task<IActionResult> Put(IEnumerable<Category> employees)
    {
        IEnumerable<Category> employeesUpdated = await _mediator.Send(new UpdateCategoriesCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesUpdated);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteCategoryByIdCommand(id));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Category employee)
    {
        await _mediator.Send(new DeleteCategoryCommand(employee));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete("Bulk")]
    public async Task<IActionResult> Delete(IEnumerable<Category> employees)
    {
        await _mediator.Send(new DeleteCategoriesCommand(employees));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }
}