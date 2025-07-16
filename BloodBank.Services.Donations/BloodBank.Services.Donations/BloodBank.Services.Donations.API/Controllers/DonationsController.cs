using BloodBank.Services.Donations.Application.Commands.AddDonation;
using BloodBank.Services.Donations.Application.Queries.GetDonationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Services.Donations.Controllers;

[Route("api/donations")]
[ApiController]
public class DonationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetDonationById(id));

        if (!result.IsSucess) return BadRequest(result.Message);

        return CreatedAtAction(nameof(GetById), new { Id = result.Data }, id);

    }

    public async Task<IActionResult> Post(AddDonation command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSucess) return BadRequest(result.Message);

        return CreatedAtAction(nameof(GetById), new { Id = result.Data }, command);

    }   

}
