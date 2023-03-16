namespace Products.Application;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
{
    readonly IProductUnitOfWork _unitOfWork;
    public AddProductCommandHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Product);

        return request.Product;
    }
}