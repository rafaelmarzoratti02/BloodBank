using BloodBank.Services.Donors.Application.Commands;
using BloodBank.Services.Donors.Application.Queries.Donor;
using BloodBank.Services.Donors.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Services.Donors.Controllers;

[Route("api/donors")]
[ApiController]
public class DonorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetDonorById(id);
        var result = await _mediator.Send(query);
        
        if(!result.IsSucess)return NotFound(result);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddDonor request)
    {
        var result = await _mediator.Send(request);
        if(!result.IsSucess) return BadRequest(result.Message);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, request); 
    }
}