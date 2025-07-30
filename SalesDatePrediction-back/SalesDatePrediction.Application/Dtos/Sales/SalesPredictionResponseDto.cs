using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Application.Dtos.Sales
{
    public record SalesPredictionResponseDto(int CustomerId, string CustomerName, DateTime? LastOrderDate, DateTime? NextPredictedOrder);
}
