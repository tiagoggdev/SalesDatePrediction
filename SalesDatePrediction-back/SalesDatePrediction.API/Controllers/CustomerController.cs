using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.UseCases.Queries.GetSalesDatePrediction;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSalesPrediction")]
        public async Task<IActionResult> GetSalesPrediction([FromQuery] GetSalesDatePredictionQuery command)
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
