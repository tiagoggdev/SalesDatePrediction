using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Products;
using SalesDatePrediction.Infrastructure.Data;

namespace SalesDatePrediction.Application.UseCases.Queries.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, Result<List<ProductResponseDto>>>
    {
        private readonly AppDbContext _context;

        public GetProductsHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Result<List<ProductResponseDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Products.AsNoTracking();

            var total = await query.CountAsync(cancellationToken);

            var items = await query
                .Select(p => new ProductResponseDto(p.Productid, p.Productname))
                .ToListAsync(cancellationToken);

            return Result<List<ProductResponseDto>>.Ok(items);
        }
    }
}
