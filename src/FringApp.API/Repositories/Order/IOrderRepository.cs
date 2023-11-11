namespace FringApp.API.Repositories.Order;

public interface IOrderRepository
{
    Task<bool> Create();
}