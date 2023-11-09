using FringApp.API.Entities;
using FringApp.API.Models.Requests;
using FringApp.API.Repositories;

namespace FringApp.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Create(CreateUserRequestModel requestModel)
    {
        User user = new()
        {
            Name = requestModel.Name,
            LastName = requestModel.LastName,
            Email = requestModel.Email,
            CellPhone = requestModel.CellPhone,
            Gender = (int)requestModel.Gender,
            ImageUrl = requestModel.ImageUrl,
            IsSubscribed = false,
            IsActive = true,
            IsDeleted = false
        };

        return await _userRepository.Create(user);
    }

    public async Task<bool> Delete(string userId)
    {
        return await _userRepository.Delete(userId);
    }

    public async Task<User> Get(string userId)
    {
        return await _userRepository.Get(userId);
    }

    public async Task<User> UnSubscribe(string userId)
    {
        var user = await Get(userId);
        if (user is null)
            return new User();

        var result = await _userRepository.UnSubscribe(userId);
        if (result)
            user.IsSubscribed = false;

        return user;
    }
}
