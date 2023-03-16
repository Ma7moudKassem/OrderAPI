namespace Categories.Test;

public class CategoryControllerPutTest
{
    readonly CategoriesController _controller;
    public CategoryControllerPutTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new CategoriesController(mediator.Object);
    }
}