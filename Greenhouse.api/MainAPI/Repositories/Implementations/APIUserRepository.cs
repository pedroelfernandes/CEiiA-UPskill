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

        public async Task<APIUser> Create(APIUser apiUser)
        {
            if (apiUser == null)
                return apiUser;

            await _db.APIUsers.AddAsync(apiUser);
            await _db.SaveChangesAsync();

            return apiUser;
        }

        public async Task<APIUser> Get(int id)
        {
            APIUser? apiUser;

            // get the user
            apiUser = await _db.APIUsers.FindAsync(id);
            return apiUser;
        }

        public async Task<APIUser> Edit(int id, string username, string email, int roleId)
        {
            _db.APIUsers.Update(await Get(id)).Property(r => r.Username).CurrentValue = username;
            _db.APIUsers.Update(await Get(id)).Property(r => r.Email).CurrentValue = email;
            _db.APIUsers.Update(await Get(id)).Property(r => r.RoleId).CurrentValue = roleId;
            await _db.SaveChangesAsync();
            return await Get(id);
        }

        public async Task<bool> ChangeState(int id)
        {
            APIUser? apiUser;

            apiUser = await _db.APIUsers.FindAsync(id);

            if (apiUser == null)
                return false;

            apiUser.Active ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
