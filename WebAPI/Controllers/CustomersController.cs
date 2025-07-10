using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Application.Features.Customers.Queries.GetAllCategories;
using Application.Features.Customers.Queries.GetJustMexico;
using Application.Features.Employees.Queries.GetCountryOfEmployees;
using Application.Features.Customers.Queries.GetCustomerByCountry;
using Application.Features.Customers.Queries.GetCustomerByContactName;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("sample")]
        public async Task<ActionResult<List<CustomerDto>>> GetSample()
        {
            var result = await _mediator.Send(new GetSampleCustomersQuery());
            return Ok(result);
        }
        [HttpGet("mexico")]
        public async Task<ActionResult<List<CustomersByMexicoDto>>> GetMexicoCustomers()
        {
            var result = await _mediator.Send(new GetCustomersByMexicoQuery());
            return Ok(result);
        }
        [HttpGet("Country")]
        public async Task<ActionResult<List<GetCountryOfEmployeeDto>>> GetCountryByEmployee([FromQuery] string country)
        {
            var result = await _mediator.Send(new GetCountryOfEmployeeDto { Country = country });
            return Ok(result);
        }

        [HttpGet("CustomerByCountry")]

        public async Task<ActionResult<List<GetCustomerByCountryDto>>> GetCustomerByCountry([FromQuery] string country)
        {
            var result = await _mediator.Send(new GetCustomerByCountryQuery { Country = country });
            return Ok(result);

        }

        [HttpGet("CustomerByContactName")]

        public async Task<ActionResult<List<GetCustomerByContactNameDto>>> GetCustomerByContactName([FromQuery] string contactName)
        {
            var result = await _mediator.Send(new GetCustomerByContactNameQuery { ContactName = contactName });
            return Ok(result);

        }
    }
}
