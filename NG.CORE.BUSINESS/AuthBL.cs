using CORE.NG.DATA.DBModel;
using CORE.NG.DATA.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NG.CORE.BUSINESS
{
    public class AuthBL : IAuthBL
    {
        private readonly IAuthRepository _repository;

        public AuthBL(IAuthRepository authRep)
        {
            this._repository = authRep;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _repository.Login(username, password);
            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            return await this._repository.Register(user, password);
        }

        public async Task<bool> UserExists(string username)
        {
            return await this._repository.UserExists(username);
        }
    }
}
