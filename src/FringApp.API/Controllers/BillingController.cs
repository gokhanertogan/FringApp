using FringApp.API.Services.Billing;
using Microsoft.AspNetCore.Mvc;

namespace FringApp.API.Controllers;

[Route("api/v1/billing")]
[ApiController]
public class BillingController : ControllerBase
{
    private readonly IBillingService _billingService;

    public BillingController(IBillingService billingService)
    {
        _billingService = billingService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> BillingInformation(string userId)
    {
        return Ok(await _billingService.GetUserBillingInformation(userId));
    }
}