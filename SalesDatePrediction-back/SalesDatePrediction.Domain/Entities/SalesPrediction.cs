using System;
using System.Collections.Generic;

namespace SalesDatePrediction.Domain.Entities;

public partial class SalesPrediction
{
    public int Custid { get; set; }

    public string CustomerName { get; set; } = null!;

    public DateTime? LastOrderDate { get; set; }

    public DateTime? NextPredictedOrder { get; set; }
}
