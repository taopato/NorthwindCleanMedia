using Application.Features.Suppliers.Queries.GetSampleSuppliers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly IMediator _mediator;
    public SuppliersController(IMediator mediator) => _mediator = mediator;

    [HttpGet("sample")]
    public async Task<ActionResult<List<SupplierDto>>> GetSample()
    {
        var result = await _mediator.Send(new GetSampleSuppliersQuery());
        return Ok(result);
    }
}
