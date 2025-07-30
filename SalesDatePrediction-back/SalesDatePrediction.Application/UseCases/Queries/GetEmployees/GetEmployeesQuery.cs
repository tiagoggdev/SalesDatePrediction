using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Employees;

namespace SalesDatePrediction.Application.UseCases.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<Result<List<EmployeesResponseDto>>>
    {
    }
}
