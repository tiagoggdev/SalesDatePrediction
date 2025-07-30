using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SalesDatePrediction.Application.Common.Responses;
using SalesDatePrediction.Application.Dtos.Products;

namespace SalesDatePrediction.Application.UseCases.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<Result<List<ProductResponseDto>>>
    {
    }
}
