using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Employees;
using SalesDatePrediction.Application.Dtos.Orders;
using SalesDatePrediction.Infrastructure.Data;

namespace SalesDatePrediction.Application.UseCases.Queries.GetEmployees
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, Result<List<EmployeesResponseDto>>>
    {
        private readonly AppDbContext _context;

        public GetEmployeesHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Result<List<EmployeesResponseDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Employees
                 .AsNoTracking();

            var total = await query.CountAsync(cancellationToken);

            var items = await query
                .Select(e => new EmployeesResponseDto(e.Empid, e.Firstname + " " + e.Lastname))
                .ToListAsync(cancellationToken);

            return Result<List<EmployeesResponseDto>>.Ok(items);
        }
    }
}
