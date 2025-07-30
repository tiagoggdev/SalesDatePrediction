using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SalesDatePrediction.Application.UseCases.Commands.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustId).GreaterThan(0);
            RuleFor(x => x.Empid).GreaterThan(0);
            RuleFor(x => x.Shipperid).GreaterThan(0);
            RuleFor(x => x.Shipname).NotEmpty();
            RuleFor(x => x.Shipaddress).NotEmpty();
            RuleFor(x => x.Shipcity).NotEmpty();
            RuleFor(x => x.Orderdate)
                .Must(date => date != default)
                .WithMessage("La fecha es obligatoria.");
            RuleFor(x => x.Requireddate)
                .Must(date => date != default)
                .WithMessage("La fecha requerida es obligatoria.");
            RuleFor(x => x.Freight).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Productid).GreaterThan(0);
            RuleFor(x => x.Unitprice).GreaterThan(0);
            RuleFor(x => x.Qty).GreaterThan(0);
            RuleFor(x => x.Discount).InclusiveBetween(0, 1);
        }
    }
}
