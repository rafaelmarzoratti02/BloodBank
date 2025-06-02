using BloodBank.Application.Services;
using BloodBank.Core.Repositories;
 using Microsoft.AspNetCore.Mvc;
 
 namespace Bloodank.Controllers;
 [Route("api/doador")]
 
 [ApiController]
 public class DoadorController : Controller
 {
    private readonly IDoadorService _doadorService;

    public DoadorController(IDoadorService doadorService)
    {
        _doadorService = doadorService;
    }

    [HttpGet]
     public async Task<IActionResult> GetAll()
     {
         var result = await _doadorService.GetAllDoadores();
         return Ok(result);
     }
 }