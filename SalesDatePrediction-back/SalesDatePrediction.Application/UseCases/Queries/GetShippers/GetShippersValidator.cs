using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SalesDatePrediction.Application.UseCases.Queries.GetSalesDatePrediction;

namespace SalesDatePrediction.Application.UseCases.Queries.GetShippers
{
    public class GetShippersValidator : AbstractValidator<GetShippersQuery>
    {
        public GetShippersValidator()
        {
        }
    }
}
