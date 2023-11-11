namespace FringApp.API.Repositories.Product;
public interface IProductRepository
{
    Task<Entities.Product> Create(Entities.Product product);
    Task<List<Entities.Product>> GetAll();
    Task<Entities.Product> Get();
    Task<bool> Delete();
    Task<bool> Update();
}