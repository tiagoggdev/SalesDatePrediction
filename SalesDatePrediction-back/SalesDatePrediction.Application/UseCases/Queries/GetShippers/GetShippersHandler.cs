using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Shippers;
using SalesDatePrediction.Infrastructure.Data;

namespace SalesDatePrediction.Application.UseCases.Queries.GetShippers
{
    public class GetShippersHandler : IRequestHandler<GetShippersQuery, Result<List<ShippersResponseDto>>>
    {
        private readonly AppDbContext _context;

        public GetShippersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<ShippersResponseDto>>> Handle(GetShippersQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Shippers
                 .AsNoTracking();

            var total = await query.CountAsync(cancellationToken);

            var items = await query
                .Select(s => new ShippersResponseDto(s.Shipperid, s.Companyname))
                .ToListAsync(cancellationToken);

            return Result<List<ShippersResponseDto>>.Ok(items);
        }
    }
}
