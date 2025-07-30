using MediatR;
using SalesDatePrediction.Application.Common.Responses;

namespace SalesDatePrediction.Application.UseCases.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Result<string>>
    {
        public int CustId { get; set; }
        public int Empid { get; set; }
        public int Shipperid { get; set; }
        public string Shipname { get; set; } = null!;
        public string Shipaddress { get; set; } = null!;
        public string Shipcity { get; set; } = null!;
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public decimal Freight { get; set; }
        public string Shipcountry { get; set; } = null!;
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public int Qty { get; set; }
        public float Discount { get; set; }
    }
}
