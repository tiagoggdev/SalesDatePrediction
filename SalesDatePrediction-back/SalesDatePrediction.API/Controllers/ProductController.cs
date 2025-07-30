using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.UseCases.Queries.GetProducts;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetProductsQuery command)
        {
            if (command == null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
