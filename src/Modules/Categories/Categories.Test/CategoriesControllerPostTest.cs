namespace Categories.Test;

public class CategoriesControllerPostTest
{
    readonly CategoriesController _controller;
    public CategoriesControllerPostTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new CategoriesController(mediator.Object);
    }
}