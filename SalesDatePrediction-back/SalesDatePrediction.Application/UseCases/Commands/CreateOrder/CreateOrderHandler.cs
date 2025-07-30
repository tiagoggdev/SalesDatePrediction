using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Infrastructure.Data;

namespace SalesDatePrediction.Application.UseCases.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result<string>>
    {
        private readonly AppDbContext _context;

        public CreateOrderHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customerExists = await _context.Customers.AnyAsync(e => e.Custid == request.CustId, cancellationToken);
            if (!customerExists)
                return Result<string>.Fail("El cliente no existe.");

            var empExists = await _context.Employees.AnyAsync(e => e.Empid == request.Empid, cancellationToken);
            if (!empExists)
                return Result<string>.Fail("El empleado no existe.");

            var shipperExists = await _context.Shippers.AnyAsync(s => s.Shipperid == request.Shipperid, cancellationToken);
            if (!shipperExists)
                return Result<string>.Fail("El transportista no existe.");

            var productExists = await _context.Products.AnyAsync(p => p.Productid == request.Productid, cancellationToken);
            if (!productExists)
                return Result<string>.Fail("El producto no existe.");

            var sql = "EXEC Sales.AddOrderWithDetails @Custid, @Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity, " +
                  "@Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry, " +
                  "@Productid, @Unitprice, @Qty, @Discount";

            var parameters = new[]
            {
            new SqlParameter("@Custid", request.CustId),
            new SqlParameter("@Empid", request.Empid),
            new SqlParameter("@Shipperid", request.Shipperid),
            new SqlParameter("@Shipname", request.Shipname),
            new SqlParameter("@Shipaddress", request.Shipaddress),
            new SqlParameter("@Shipcity", request.Shipcity),
            new SqlParameter("@Orderdate", request.Orderdate),
            new SqlParameter("@Requireddate", request.Requireddate),
            new SqlParameter("@Shippeddate", (object?)request.Shippeddate ?? DBNull.Value),
            new SqlParameter("@Freight", request.Freight),
            new SqlParameter("@Shipcountry", request.Shipcountry),
            new SqlParameter("@Productid", request.Productid),
            new SqlParameter("@Unitprice", request.Unitprice),
            new SqlParameter("@Qty", request.Qty),
            new SqlParameter("@Discount", request.Discount)
        };

            await _context.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);

            return Result<string>.Ok("La orden ha sido creada");
        }
    }
}
