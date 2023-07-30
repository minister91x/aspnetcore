using WebCoreAPI.EntitiesFrameWork.Dbcontext;
using WebCoreAPI.EntitiesFrameWork.Entities;
using WebCoreAPI.Models;

namespace WebCoreAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyShopUnitOfWorkDbContext _context;

        public AccountRepository(MyShopUnitOfWorkDbContext context)
        {
            _context = context;
        }
        public User UserLogin(UserLoginRequestData requestData)
        {
            var user = _context.user.ToList().FindAll(s => s.UserName == requestData.UserName &&
            s.Password == requestData.Password).FirstOrDefault();

            if (user == null) { return new User(); }
            return user;
        }
    }
}
