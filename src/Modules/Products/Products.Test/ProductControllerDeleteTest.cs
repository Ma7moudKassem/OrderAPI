namespace Products.Test;

public class ProductControllerDeleteTest
{
    readonly ProductsController _controller;
    public ProductControllerDeleteTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new ProductsController(mediator.Object);
    }
}
