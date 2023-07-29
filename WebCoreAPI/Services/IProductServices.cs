using WebCoreAPI.EntitiesFrameWork.Entities;

namespace WebCoreAPI.Services
{
    public interface IProductServices
    {
        Task<int > AddProductAsync( Product product );
        Task<List<Product>> GetAll();
    }
}
