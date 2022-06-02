using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;

namespace MainAPI.Repositories.Implementations
{
    public class APIUserRepository : IAPIUserRepository
    {
        private readonly ApplicationDbContext _db;

        public APIUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(APIUser apiUser)
        {
            if (apiUser == null)
                return  false;

            await _db.APIUsers.AddAsync(apiUser);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<APIUser> Get(int id)
        {
            APIUser? apiUser;

            // get the user
            apiUser = await _db.APIUsers.FindAsync(id);
            return apiUser;
        }

        public async Task<APIUser> Edit(APIUser apiUser)
        {
            _db.APIUsers.Update(apiUser);
            await _db.SaveChangesAsync();
            return apiUser;
        }

        public async Task<bool> Delete(int id)
        {
            APIUser? apiUser;

            apiUser = await _db.APIUsers.FindAsync(id);

            if (apiUser == null)
                return false;

            _db.APIUsers.Update(apiUser).Property(u => u.Active).CurrentValue = false;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
