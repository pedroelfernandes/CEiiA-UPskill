using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories;

namespace MainAPI.Services
{
    public class UserServices
    {
        public static async Task<bool> AuthenticateUser(string username, string password, ApplicationDbContext db)
        {
            // resultado provisório enquanto não é validado um token para o user
            return UserRepository.AuthenticateUser(username, password, db);
            // quando tivermos a atenticação em vez de retornar um bool, devolvemos uma string com o token
        }

    }
}
