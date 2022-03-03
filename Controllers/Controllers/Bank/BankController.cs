using Application.Service.Bank.Interface;
using Domain.Record.Response.Bank;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Controllers.Controllers.Bank;

[Route("api/[controller]")]
[ApiController]
public class BankController : ControllerBase
{
    private readonly IBankService _bankService;

    public BankController(IBankService bankService)
    {
        _bankService = bankService;
    }

    [HttpGet]
    public async Task<ActionResult<BankResponse>> Banks()
    {
        return Ok(await _bankService.GetBanks());
    }
}
