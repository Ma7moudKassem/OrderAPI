namespace Products.API;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    readonly IMediator _mediator;
    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Product> employees = await _mediator.Send(new GetProductQuery());

        if (ModelState.IsValid)
            return Ok(employees);

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Product employee = await _mediator.Send(new GetProductByIdQuery(id));

        if (ModelState.IsValid)
            return Ok(employee);

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product employee)
    {
        Product employeeCreated = await _mediator.Send(new AddProductCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeCreated);

        return BadRequest();
    }

    [HttpPost("Bulk")]
    public async Task<IActionResult> Post(IEnumerable<Product> employees)
    {
        IEnumerable<Product> employeesCreated = await _mediator.Send(new AddProductsCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesCreated);

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(Product employee)
    {
        Product employeeUpdated = await _mediator.Send(new UpdateProductCommand(employee));

        if (ModelState.IsValid)
            return Ok(employeeUpdated);

        return BadRequest();
    }

    [HttpPut("Bulk")]
    public async Task<IActionResult> Put(IEnumerable<Product> employees)
    {
        IEnumerable<Product> employeesUpdated = await _mediator.Send(new UpdateProductsCommand(employees));

        if (ModelState.IsValid)
            return Ok(employeesUpdated);

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteProductByIdCommand(id));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Product employee)
    {
        await _mediator.Send(new DeleteProductCommand(employee));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }

    [HttpDelete("Bulk")]
    public async Task<IActionResult> Delete(IEnumerable<Product> employees)
    {
        await _mediator.Send(new DeleteProductsCommand(employees));

        if (ModelState.IsValid)
            return Ok("Data Deleted Successfully");

        return BadRequest();
    }
}