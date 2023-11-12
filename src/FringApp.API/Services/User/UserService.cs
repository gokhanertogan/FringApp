using FringApp.API.Models.Requests;
using FringApp.API.Repositories.User;

namespace FringApp.API.Services.User;
public class UserService : IUserService
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;

    public UserService(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
    {
        _userWriteRepository = userWriteRepository;
        _userReadRepository = userReadRepository;
    }
    public async Task<Entities.User> Create(CreateUserRequestModel requestModel)
    {
        Entities.User user = new()
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

        return await _userWriteRepository.AddAsync(user);
    }

    public async Task<bool> Delete(string userId)
    {
        return await _userWriteRepository.RemoveAsync(userId);
    }

    public async Task<Entities.User> Get(string userId)
    {
        return await _userReadRepository.GetByIdAsync(userId);
    }

    public async Task<Entities.User> UnSubscribe(string userId)
    {
        var user = await Get(userId);
        if (user is null)
            return new Entities.User();

        var result = await _userWriteRepository.UnSubscribe(userId);
        if (result)
            user.IsSubscribed = false;

        return user;
    }
}
