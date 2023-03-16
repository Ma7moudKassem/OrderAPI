namespace Products.Application;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    IProductUnitOfWork _unitOfWork;
    public GetProductByIdQueryHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync(request.Id);
}
