namespace Products.Test;

public class ProductsControllerPostTest
{
    readonly ProductsController _controller;
    public ProductsControllerPostTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new ProductsController(mediator.Object);
    }
}