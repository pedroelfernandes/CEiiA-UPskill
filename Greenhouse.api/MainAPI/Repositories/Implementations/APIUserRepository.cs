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
                throw new Exception("User not defined.");

            await _db.APIUsers.AddAsync(apiUser);
            await _db.SaveChangesAsync();

            return apiUser;
        }

        public async Task<APIUser> Get(int id)
        {
            // get the user
            APIUser? apiUser = await _db.APIUsers.FindAsync(id);

            if (apiUser == null)
                throw new Exception("User not found.");

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
            APIUser? apiUser = await _db.APIUsers.FindAsync(id);

            if (apiUser == null)
                return false;

            apiUser.IsActive ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
