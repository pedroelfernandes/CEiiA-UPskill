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

        public async Task<Role> Create(Role role)
        {
            if (role == null)
                throw new Exception("Role not defined.");

            await _db.Roles.AddAsync(role);
            await _db.SaveChangesAsync();
            return role;
        }

        public async Task<List<Role>> Get()
        {
            List<int> index = _db.Roles.Select(u=>u.Id).ToList();

            List<Role> roles = new();

            foreach (int id in index)
            {
                roles.Add(await _db.Roles.FindAsync(id));
            }

            if (roles == null)
                throw new Exception("Role not found.");

            return roles;
        }

        public async Task<Role> GetRole(int id)
        {
            return await _db.Roles.FindAsync(id);
        }

        public async Task<Role> Edit(Role role)
        {
            if (role == null)
                throw new Exception("Role not defined.");
            _db.Roles.Update(role);
            await _db.SaveChangesAsync();
            return role;
        }

        public async Task<bool> ChangeState(int id)
        {
            Role role = await _db.Roles.FindAsync(id);

            if (role == null)
                return false;

            role.IsActive ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
