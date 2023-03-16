namespace Products.Application;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    readonly IProductUnitOfWork _unitOfWork;
    public DeleteProductCommandHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Product);

        return Unit.Value;
    }
}