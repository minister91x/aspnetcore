using WebCoreAPI.EntitiesFrameWork.Dbcontext;
using WebCoreAPI.EntitiesFrameWork.Entities;

namespace WebCoreAPI.Repository
{
    public class ProductGenericRepository : IProductGenericRepository
    {
        private readonly MyShopUnitOfWorkDbContext _context;
        public ProductGenericRepository(MyShopUnitOfWorkDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.sanpham.ToList();
        }
    }
}
