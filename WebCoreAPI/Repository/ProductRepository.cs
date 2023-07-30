using WebCoreAPI.EntitiesFrameWork.Dbcontext;
using WebCoreAPI.EntitiesFrameWork.Entities;

namespace WebCoreAPI.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly MyShopUnitOfWorkDbContext _context;

        public ProductRepository(MyShopUnitOfWorkDbContext context)
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
