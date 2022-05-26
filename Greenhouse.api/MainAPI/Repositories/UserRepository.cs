using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Repositories
{
    public class UserRepository
    {
        public static bool AuthenticateUser(string name, string password, ApplicationDbContext db)
        {
            User u = db.Users.FirstOrDefault(u => u.Username == name);
            
            if ( u != null)
            {
                return u.Password == password;
            }
            return false;
        }
    }
}
