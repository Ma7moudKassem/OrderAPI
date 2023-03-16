namespace Suppliers.Test;

public class SuppliersControllerPostTest
{
    readonly SuppliersController _controller;
    public SuppliersControllerPostTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new SuppliersController(mediator.Object);
    }
}