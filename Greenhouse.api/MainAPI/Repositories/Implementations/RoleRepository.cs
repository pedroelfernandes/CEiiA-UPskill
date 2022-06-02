using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;

namespace MainAPI.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;

        public RoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Role role)
        {
            if (role == null)
                return false;

            await _db.Roles.AddAsync(role);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Role> Get(int id)
        {
            Role? role;

            // get the role
            role = await _db.Roles.FindAsync(id);
            return role;
        }

        public async Task<Role> Edit(Role role)
        {
            _db.Roles.Update(role);
            await _db.SaveChangesAsync();
            return role;
        }

        public async Task<bool> Delete(int id)
        {
            Role? role;

            role = await _db.Roles.FindAsync();

            if (role == null)
                return false;

            _db.Roles.Update(role).Property(u => u.Active).CurrentValue = false;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
