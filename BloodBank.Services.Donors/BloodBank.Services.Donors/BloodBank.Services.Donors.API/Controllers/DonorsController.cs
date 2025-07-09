using BloodBank.Services.Donors.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Services.Donors.Controllers;

[Route("api/donors")]
[ApiController]
public class DonorsController
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<Guid> AddDonor(AddDonor request)
    {
        var result = await _mediator.Send(request);
        
        return result;
    }
}