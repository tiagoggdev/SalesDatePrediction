using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SalesDatePrediction.Application.UseCases.Queries.GetEmployees;

namespace SalesDatePrediction.Application.UseCases.Queries.GetProducts
{
    public class GetProductsValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductsValidator()
        {
        }
    }
}
