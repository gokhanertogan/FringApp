namespace FringApp.API.Repositories;

public interface IOrderRepository
{
    Task<bool> Create();
}