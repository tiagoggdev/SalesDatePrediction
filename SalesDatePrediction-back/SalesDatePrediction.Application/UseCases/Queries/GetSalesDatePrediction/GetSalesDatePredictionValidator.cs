using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SalesDatePrediction.Application.UseCases.Queries.GetProducts;

namespace SalesDatePrediction.Application.UseCases.Queries.GetSalesDatePrediction
{
    public class GetSalesDatePredictionValidator : AbstractValidator<GetSalesDatePredictionQuery>
    {
        public GetSalesDatePredictionValidator()
        {
            RuleFor(x => x.CustomerName)
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.CustomerName));
            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber must be at least 1.");
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber must be at least 1.");
        }
    }
}
