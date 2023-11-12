using System.Net;
using FringApp.API.Entities;
using FringApp.API.Models.Requests;
using FringApp.API.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace FringApp.API.Controllers;

[Route("api/v1/user")]
[ApiController]
public class UserControllers : ControllerBase
{
    private readonly IUserService _userService;
    public UserControllers(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateUserRequestModel request)
    {
        var user = await _userService.Create(request);
        return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
    }

    [HttpGet("{userId}", Name = "GetUser")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(string userId)
    {
        var user = await _userService.Get(userId);
        return Ok(user);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(string userId)
    {
        var result = await _userService.Delete(userId);
        return Ok(result);
    }

    [HttpPatch("UnSubscribe/{userId}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UnSubscribe(string userId)
    {
        var user = await _userService.UnSubscribe(userId);
        return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
    }
}