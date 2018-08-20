using System.Threading.Tasks;
using CORE.NG.DATA.DBModel;

namespace CORE.NG.DATA.Repository
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}