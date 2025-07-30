using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.UseCases.Queries.GetCustomerOrders;
using SalesDatePrediction.Application.UseCases.Queries.GetEmployees;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetEmployeesQuery command)
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
