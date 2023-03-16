namespace Products.Application;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
{
    readonly IProductUnitOfWork _unitOfWork;
    public GetProductQueryHandler(IProductUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync();
}