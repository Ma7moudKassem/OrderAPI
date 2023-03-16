namespace Products.Test;

public class ProductControllerGetTest
{
    readonly ProductsController _controller;
    public ProductControllerGetTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new ProductsController(mediator.Object);
    }

    [Fact]
    public async Task Get_WhenCalled_ReturnOk()
    {
        IActionResult okResult = await _controller.Get();

        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public async Task GetById_UnknownId_ReturnNotFound()
    {
        IActionResult notFoundResult = await _controller.GetById(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(notFoundResult);
    }
}
