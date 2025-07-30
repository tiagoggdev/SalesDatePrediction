using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Sales;

namespace SalesDatePrediction.Application.UseCases.Queries.GetSalesDatePrediction
{
    public class GetSalesDatePredictionQuery : IRequest<Result<PaginatedResult<SalesPredictionResponseDto>>>
    {
        public string? CustomerName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
