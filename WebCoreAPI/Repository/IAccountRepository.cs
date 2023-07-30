using WebCoreAPI.EntitiesFrameWork.Entities;
using WebCoreAPI.Models;

namespace WebCoreAPI.Repository
{
    public interface IAccountRepository
    {
        User UserLogin(UserLoginRequestData requestData);
    }
}
