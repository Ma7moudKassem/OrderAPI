namespace Products.Application;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    readonly IProductUnitOfWork _unitOfWork;
    public UpdateProductCommandHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Product);

        return request.Product;
    }
}