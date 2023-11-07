using System.Net;
using FringApp.API.Entities;
using FringApp.API.Models.Requests;
using FringApp.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FringApp.API.Controllers;

[Route("api/v1/user")]
[ApiController]
public class UserControllers : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserControllers(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateUserRequestModel request)
    {
        User user = new()
        {
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            CellPhone = request.CellPhone,
            Gender = (int)request.Gender,
            ImageUrl = request.ImageUrl,
            IsApproved = true,
            IsActive = true
        };

        await _userRepository.Create(user);
        return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
    }

    [HttpGet("{userId}", Name = "GetUser")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(string userId)
    {
        var user = await _userRepository.Get(userId);
        return Ok(user);
    }

    [HttpDelete("Delete/{userId}")]
    public async Task<IActionResult> Delete(string userId)
    {
        var result = await _userRepository.Delete(userId);
        return Ok(result);
    }

    [HttpPatch("UnSubscribe/{userId}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UnSubscribe(string userId)
    {
        var user = await _userRepository.Get(userId);
        if (user is null)
            return NotFound();

        await _userRepository.UnSubscribe(userId);
        return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
    }

    [HttpGet("Billing/{userId}")]
    public async Task<IActionResult> BillingInformation(string userId)
    {
        var user = await _userRepository.Get(userId);
        if (user is null)
            return NotFound();

        var result = await _userRepository.GetBillingInformation(userId);
        return Ok(result);
    }

    [HttpGet("{userId}/ActivePackage")]
    public async Task<IActionResult> GetActivePackage(string userId)
    {
        var user = await _userRepository.Get(userId);
        if (user is null)
            return NotFound();

        var result = await _userRepository.GetUserActivePackage(userId);
        return Ok(result);
    }

    [HttpGet("{userId}/PackageHistories")]
    public async Task<IActionResult> GetUserPackageHistories(string userId)
    {
        var user = await _userRepository.Get(userId);
        if (user is null)
            return NotFound();

        var result = await _userRepository.GetUserPackageHistories(userId);
        return Ok(result);
    }
    
}