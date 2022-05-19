using MainAPI.Data;
using MainAPI.Models;

namespace MainAPI.Repositories
{
    public class APIRepository
    {
        private readonly ApplicationDbContext _db;


        public APIRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public List<API> GetAPIs() =>
            _db.APIs.ToList();
    }
}
