using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Shippers;

namespace SalesDatePrediction.Application.UseCases.Queries.GetShippers
{
    public class GetShippersQuery : IRequest<Result<List<ShippersResponseDto>>>
    {
    }
}
