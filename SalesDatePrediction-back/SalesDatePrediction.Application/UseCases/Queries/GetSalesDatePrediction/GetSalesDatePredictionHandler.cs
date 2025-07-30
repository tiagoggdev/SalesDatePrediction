using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Products;
using SalesDatePrediction.Application.Dtos.Sales;
using SalesDatePrediction.Infrastructure.Data;

namespace SalesDatePrediction.Application.UseCases.Queries.GetSalesDatePrediction
{
    public class GetSalesDatePredictionHandler : IRequestHandler<GetSalesDatePredictionQuery, Result<PaginatedResult<SalesPredictionResponseDto>>>
    {
        private readonly AppDbContext _context;

        public GetSalesDatePredictionHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Result<PaginatedResult<SalesPredictionResponseDto>>> Handle(GetSalesDatePredictionQuery request, CancellationToken cancellationToken)
        {
            var query = _context.SalesPredictions.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.CustomerName))
            {
                query = query.Where(sp => sp.CustomerName.Contains(request.CustomerName));
            }

            var total = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(sp => new SalesPredictionResponseDto(sp.Custid ,sp.CustomerName, sp.LastOrderDate, sp.NextPredictedOrder))
                .ToListAsync(cancellationToken);

            var paginated = new PaginatedResult<SalesPredictionResponseDto>()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = total,
                Items = items
            };

            return Result<PaginatedResult<SalesPredictionResponseDto>>.Ok(paginated);
        }
    }
}
