using FringApp.API.Entites;
using FringApp.API.Models.Requests;
using FringApp.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FringApp.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserControllers : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserControllers(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequestModel request)
    {
        User user = new()
        {
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            CellPhone = request.CellPhone,
            Gender = request.Gender,
            ImageUrl = request.ImageUrl,
            IsApproved =true,
            IsActive = true
        };

        var result = await _userRepository.Create(user);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(string userId)
    {
        var user = await _userRepository.Get(userId);
        return Ok(user);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string userId)
    {
        var result = await _userRepository.Delete(userId);
        return Ok(result);
    }

    [HttpPatch]
    public async Task<IActionResult> UnSubscribe(string userId)
    {
        var result = await _userRepository.UnSubscribe(userId);
        return Ok(result);
    }

    [HttpGet(Name ="BillingInformation")]
    public async Task<IActionResult> BillingInformation(string userId)
    {
        var result = await _userRepository.GetBillingInformation(userId);
        return Ok(result);
    }
}