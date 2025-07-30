using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Orders;
using SalesDatePrediction.Infrastructure.Data;

namespace SalesDatePrediction.Application.UseCases.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersHandler : IRequestHandler<GetCustomerOrdersQuery, Result<PaginatedResult<OrdersByCustomerResponseDto>>>
    {
        private readonly AppDbContext _context;

        public GetCustomerOrdersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<PaginatedResult<OrdersByCustomerResponseDto>>> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            var exists = await _context.Customers.AnyAsync(c => c.Custid == request.CustomerId, cancellationToken);
            if (!exists)
                return Result<PaginatedResult<OrdersByCustomerResponseDto>>.Fail("Cliente no encontrado.");

            var query = _context.Orders
                .AsNoTracking()
                .Where(o => o.Custid == request.CustomerId);

            var total = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(o => o.Orderdate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(o => new OrdersByCustomerResponseDto(o.Orderid, o.Requireddate, o.Shippeddate, o.Shipname, o.Shipaddress, o.Shipcity))
                .ToListAsync(cancellationToken);

            var paginated = new PaginatedResult<OrdersByCustomerResponseDto>
            {
                Items = items,
                TotalItems = total,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            return Result<PaginatedResult<OrdersByCustomerResponseDto>>.Ok(paginated);
        }
    }
}
