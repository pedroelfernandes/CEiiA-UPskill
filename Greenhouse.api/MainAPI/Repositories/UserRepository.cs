using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Repositories
{
    public class UserRepository
    {
        public static bool AuthenticateUser(string name, string password, ApplicationDbContext db)
        {
            APIUser u = db.APIUsers.FirstOrDefault(u => u.Username == name);
            
            if ( u != null)
            {
                return u.Password == password;
            }
            return false;
        }
    }
}
