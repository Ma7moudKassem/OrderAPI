namespace Products.Application;

public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand>
{
    readonly IProductUnitOfWork _unitOfWork;
    public DeleteProductByIdCommandHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Id);

        return Unit.Value;
    }
}