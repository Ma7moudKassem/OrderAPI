namespace Products.Application;

public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand>
{
    readonly IProductUnitOfWork _unitOfWork;
    public DeleteProductsCommandHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Products);

        return Unit.Value;
    }
}