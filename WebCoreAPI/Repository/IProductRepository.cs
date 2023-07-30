using WebCoreAPI.EntitiesFrameWork.Entities;

namespace WebCoreAPI.Repository
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(Product product);
        Task<List<Product>> GetAll();
    }
}
