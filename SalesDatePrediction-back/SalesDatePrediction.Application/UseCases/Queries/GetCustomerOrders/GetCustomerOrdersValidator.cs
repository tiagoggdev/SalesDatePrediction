using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SalesDatePrediction.Application.UseCases.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersValidator : AbstractValidator<GetCustomerOrdersQuery>
    {
        public GetCustomerOrdersValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber must be at least 1.");
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber must be at least 1.");

        }
    }
}
