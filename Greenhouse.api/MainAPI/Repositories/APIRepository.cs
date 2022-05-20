using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Repositories
{
    public class APIRepository
    {
        public static List<API> GetAPIs(ApplicationDbContext db) =>
            db.APIs.ToList();
    }
}
