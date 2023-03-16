namespace Products.Application;

public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, IEnumerable<Product>>
{
    readonly IProductUnitOfWork _unitOfWork;
    public UpdateProductsCommandHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Product>> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Products);

        return request.Products;
    }
}