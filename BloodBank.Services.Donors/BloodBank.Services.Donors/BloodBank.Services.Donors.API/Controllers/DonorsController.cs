using BloodBank.Services.Donors.Application.Commands;
using BloodBank.Services.Donors.Application.Queries.Donor;
using BloodBank.Services.Donors.Application.ViewModels;
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
    
    [HttpGet("{id}")]
    public async Task<DonorViewModel> GetDonorById(Guid id)
    {
        var query = new GetDonorById(id);
        var result = await _mediator.Send(query);
        
        return result;
    }

    [HttpPost]
    public async Task<Guid> AddDonor(AddDonor request)
    {
        var result = await _mediator.Send(request);
        
        return result;
    }
}