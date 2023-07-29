using WebCoreAPI.EntitiesFrameWork.Dbcontext;
using WebCoreAPI.EntitiesFrameWork.Entities;

namespace WebCoreAPI.Services
{
    public class ProductServices : IProductServices
    {
        private readonly MyShopUnitOfWorkDbContext _context;

        public ProductServices(MyShopUnitOfWorkDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _context.sanpham.Add(product);
            _context.SaveChanges();
            return 1;
        }

        public async Task<List<Product>> GetAll()
        {
            var result = _context.sanpham.ToList();
            return result;
        }
    }
}
