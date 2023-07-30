using WebCoreAPI.Repository;
using WebCoreAPI.Services;

namespace WebCoreAPI.UnitOfWork
{
    public interface IMyShopUnitOfWork
    {
        //  public IProductRepository _productRepository { get; }
        public IProductGenericRepository _productGenericRepository { get; }
        public IAccountRepository _accountRepository { get; }
        int SaveDataToDB();
    }
}
