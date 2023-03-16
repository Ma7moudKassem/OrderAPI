namespace Products.Application;

public class AddProductsCommandHandler : IRequestHandler<AddProductsCommand, IEnumerable<Product>>
{
    readonly IProductUnitOfWork _unitOfWork;
    public AddProductsCommandHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Product>> Handle(AddProductsCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Products);

        return request.Products;
    }
}