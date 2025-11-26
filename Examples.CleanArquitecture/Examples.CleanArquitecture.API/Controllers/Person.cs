using Examples.CleanArquitecture.Application.DTO;
using Examples.CleanArquitecture.Application.Features.Person.Queries.GetPerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examples.CleanArquitecture.API.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public PersonController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    //// GET: api/<LeaveTypesController>
    //[HttpGet]
    //public async Task<IReadOnlyList<PersonDto>> Get()
    //{
    //    var leaveTypes = await _mediator.Send(new GetPersonsQuery());

    //    return leaveTypes;
    //}

    // GET api/<LeaveTypesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetPersonByIdQuery(id));

        return Ok(leaveType);
    }

    [HttpGet("dni/{dni}")]
    public async Task<ActionResult<PersonDto>> Get(string dni)
    {
        var leaveType = await _mediator.Send(new GetPersonByDniQuery(dni));

        return Ok(leaveType);
    }

    //// POST api/<LeaveTypesController>
    //[HttpPost]
    //[ProducesResponseType(201)]
    //[ProducesResponseType(400)]
    //public async Task<ActionResult> Post(CreateLeaveTypeCommand leaveType)
    //{
    //    var response = await _mediator.Send(leaveType);

    //    return CreatedAtAction(nameof(Get), new { id = response }, null);
    //}

    //// PUT api/<LeaveTypesController>/
    //[HttpPut("{id}")]
    //[ProducesResponseType(400)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    //public async Task<ActionResult> Put(UpdateLeaveTypeCommand leaveType)
    //{
    //    await _mediator.Send(leaveType);

    //    return NoContent();
    //}

    //// DELETE api/<LeaveTypesController>/5
    //[HttpDelete("{id}")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    //public async Task<ActionResult> Delete(int id)
    //{
    //    var command = new DeleteLeaveTypeCommand { Id = id };
    //    await _mediator.Send(command);

    //    return NoContent();
    //}
}
