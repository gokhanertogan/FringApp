using FringApp.API.Services.Subscription;
using Microsoft.AspNetCore.Mvc;

namespace FringApp.API.Controllers;

[Route("api/v1/subscription")]
[ApiController]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;
    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet("{userId}/CurrentSubscription")]
    public async Task<IActionResult> GetCurrentSubscription(string userId)
    {
        return Ok(await _subscriptionService.GetCurrentSubscription(userId));
    }

    [HttpGet("{userId}/SubscriptionHistories")]
    public async Task<IActionResult> GetUserPackageHistories(string userId)
    {
        return Ok(await _subscriptionService.GetUserSubscriptionHistories(userId));
    }
}