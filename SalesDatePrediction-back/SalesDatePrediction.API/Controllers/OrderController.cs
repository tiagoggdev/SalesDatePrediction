using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.UseCases.Commands.CreateOrder;
using SalesDatePrediction.Application.UseCases.Queries.GetCustomerOrders;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetByCustomerId")]
        public async Task<IActionResult> GetByCustomerId([FromQuery] GetCustomerOrdersQuery command)
        {
            if (command == null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
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
