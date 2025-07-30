using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SalesDatePrediction.Application.UseCases.Queries.GetCustomerOrders;

namespace SalesDatePrediction.Application.UseCases.Queries.GetEmployees
{
    public class GetEmployeesValidator : AbstractValidator<GetEmployeesQuery>
    {
        public GetEmployeesValidator()
        {
        }
    }
}
