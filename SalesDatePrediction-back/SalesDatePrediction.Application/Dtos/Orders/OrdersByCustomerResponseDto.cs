using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Application.Dtos.Orders
{
    public record OrdersByCustomerResponseDto(
        int OrderId,
        DateTime RequiredDate,
        DateTime? ShippedDate,
        string ShipName,
        string Shipaddress,
        string Shipcity
        );
}
