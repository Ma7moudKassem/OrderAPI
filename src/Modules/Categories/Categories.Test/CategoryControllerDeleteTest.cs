namespace Categories.Test;

public class CategoryControllerDeleteTest
{
    readonly CategoriesController _controller;
    public CategoryControllerDeleteTest()
    {
        Mock<IMediator> mediator = new Mock<IMediator>();
        _controller = new CategoriesController(mediator.Object);
    }
}
