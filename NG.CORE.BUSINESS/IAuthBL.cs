using System.Threading.Tasks;
using CORE.NG.DATA.DBModel;

namespace NG.CORE.BUSINESS
{
    public interface IAuthBL
    {
        Task<User> Login(string username, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExists(string username);
    }
}