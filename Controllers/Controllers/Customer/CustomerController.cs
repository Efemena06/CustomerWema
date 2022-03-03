using Application.Commands.Customer.CreateCustomer;
using Application.Queries.Customer;
using Domain.Record.Request.Customer;
using Domain.Record.Response.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers.Controllers.Customer;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<List<CustomerResponse>>> Customer()
    {
        return Ok(await _mediator.Send(new GetAllCustomerQuery()));
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<CustomerResponse>>> AddCustomer(CustomerDto customerDto)
    {
        return CreatedAtRoute(await _mediator.Send(new CreateCustomerCommand(customerDto)), customerDto);
    }
}
