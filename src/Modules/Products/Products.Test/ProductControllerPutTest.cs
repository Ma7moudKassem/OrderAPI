namespace Products.Test;

public class ProductControllerPutTest
{
    readonly ProductsController _controller;
    public ProductControllerPutTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new ProductsController(mediator.Object);
    }
}