namespace Suppliers.Test;

public class SupplierControllerPutTest
{
    readonly SuppliersController _controller;
    public SupplierControllerPutTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new SuppliersController(mediator.Object);
    }
}