namespace FringApp.API.Repositories.User;

public interface IUserWriteRepository : IWriteRepository<Entities.User>
{
    Task<bool> UnSubscribe(string userId);
}