using CORE.NG.DATA.Context;
using System.ComponentModel.DataAnnotations;

namespace CORE.NG.DATA.DBModel
{
    public class User: ISupportIdentity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
