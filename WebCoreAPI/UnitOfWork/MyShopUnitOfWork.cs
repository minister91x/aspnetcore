using WebCoreAPI.EntitiesFrameWork.Dbcontext;
using WebCoreAPI.Repository;

namespace WebCoreAPI.UnitOfWork
{
    public class MyShopUnitOfWork : IMyShopUnitOfWork
    {
        private readonly MyShopUnitOfWorkDbContext _dbContext;
       // public IProductRepository _productRepository { get; set; }
       public IProductGenericRepository _productGenericRepository { get; set; }
        public IAccountRepository _accountRepository { get; set; }
        public MyShopUnitOfWork(MyShopUnitOfWorkDbContext dbContext,
                          IProductGenericRepository productGenericRepository,
                          IAccountRepository accountRepository)
        {
            _dbContext = dbContext;
            _productGenericRepository = productGenericRepository;
            _accountRepository = accountRepository;
        }
        public int SaveDataToDB()
        {
            return _dbContext.SaveChanges();
        }
    }
}
