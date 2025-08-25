using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Queries;
using MyApp.Core.Entities;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employee)
        {
            var result = await sender.Send(new AddEmployeeCommand(employee));

            return Ok(result);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployeeAsync()
        {
            var result = await sender.Send(new GetAllEmployeesQuery());

            return Ok(result);
        }

        [HttpGet("employees/{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));

            return Ok(result);
        }
    }
}
