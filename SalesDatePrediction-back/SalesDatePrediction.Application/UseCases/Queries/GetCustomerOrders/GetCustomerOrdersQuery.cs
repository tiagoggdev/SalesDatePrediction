using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Orders;

namespace SalesDatePrediction.Application.UseCases.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersQuery() : IRequest<Result<PaginatedResult<OrdersByCustomerResponseDto>>>
    {
        public int CustomerId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
