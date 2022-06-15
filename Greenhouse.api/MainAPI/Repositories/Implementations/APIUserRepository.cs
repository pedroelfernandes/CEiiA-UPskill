using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Repositories.Implementations
{
    public class APIUserRepository : IAPIUserRepository
    {
        private readonly ApplicationDbContext _db;


        public APIUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<APIUser> Create(APIUser apiUser)
        {
            if (apiUser == null)
                throw new Exception("User not defined.");

            await _db.APIUsers.AddAsync(apiUser);
            await _db.SaveChangesAsync();

            return apiUser;
        }


        public async Task<List<APIUser>> Get() =>
            await _db.APIUsers.Include(u => u.Role).ToListAsync();


        public async Task<APIUser> Get(int id) =>
            await _db.APIUsers.Include(u => u.Role).FirstAsync(u => u.Id == id);


        public async Task<APIUser> Edit(APIUser apiUser)
        {
            if (apiUser == null)
                throw new Exception("APIUser not defined.");

            _db.APIUsers.Update(apiUser);
            await _db.SaveChangesAsync();
            return apiUser;
        }


        public async Task<bool> ChangeState(int id)
        {
            APIUser? apiUser = await _db.APIUsers.FindAsync(id);

            if (apiUser == null)
                return false;

            apiUser.IsActive ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
