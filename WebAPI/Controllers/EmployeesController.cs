using Application.Features.Employees.Queries.GetAllEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Employees.Queries.GetMrEmployees;
using Application.Features.Employees.Queries.GetTitleOfEmployees;
using Application.Features.Employees.Queries.GetCountryOfEmployees;
using Microsoft.AspNetCore.Authorization;


namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("just mr")]
        public async Task<ActionResult<List<EmployeeMrDto>>> GetMrEmployees()
        {
            var result = await _mediator.Send(new GetMrEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("Country")]
        public async Task<ActionResult<List<GetCountryOfEmployeeDto>>> GetEmployeesByCountry([FromQuery] string country)
        {
            var result = await _mediator.Send(new GetCountryOfEmployeesQuery());
            return Ok(result);
        }
    }
}