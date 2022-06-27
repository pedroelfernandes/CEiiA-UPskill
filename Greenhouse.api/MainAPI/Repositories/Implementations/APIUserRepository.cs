using MainAPI.Data;
using MainAPI.Models;
using MainAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Repositories.Implementations
{
    public class APIUserRepository : IAPIUserRepository
    {
        private readonly ApplicationDbContext _db;

        private readonly IRoleRepository _roleRepository;


        public APIUserRepository(ApplicationDbContext db, IRoleRepository roleRepository)
        {
            _db = db;
            _roleRepository = roleRepository;
        }


        public async Task<APIUser> Create(APIUser apiUser)
        {
            if (apiUser == null)
                throw new Exception("User not defined.");

            await _db.APIUsers.AddAsync(apiUser);
            await _db.SaveChangesAsync();

            apiUser.Role = await _roleRepository.GetRole(apiUser.RoleId);

            return apiUser;
        }


        public async Task<List<APIUser>> Get() =>
            await _db.APIUsers.Include(u => u.Role).ToListAsync();


        public async Task<APIUser> Get(int id) =>
            await _db.APIUsers.Include(u => u.Role).FirstAsync(u => u.Id == id);


        public async Task<APIUser> Edit(APIUser apiUser, string? oldPassword, string? newPassword)
        {
            if (apiUser == null)
                throw new Exception("APIUser not defined.");

            bool exists = await _db.APIUsers.AnyAsync(u => u.Id == apiUser.Id);

            _db.APIUsers.Attach(apiUser);

            if (oldPassword != null && await CheckOldPassword(apiUser.Id, oldPassword))
            {
                apiUser.Password = newPassword;
                _db.Entry(apiUser).Property(u => u.Password).IsModified = true;
            }

            _db.Entry(apiUser).Property(u => u.Username).IsModified = true;
            _db.Entry(apiUser).Property(u => u.Email).IsModified = true;
            _db.Entry(apiUser).Property(u => u.RoleId).IsModified = true;

            await _db.SaveChangesAsync();
            return apiUser;
        }

        private async Task<bool> CheckOldPassword(int id, string oldPassword)
        {
            APIUser apiUser = await _db.APIUsers.FindAsync(id);
            return apiUser.Password == oldPassword;

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


        public async Task<APIUser> Authorized(string username, string password)
        {
            APIUser apiUser = await _db.APIUsers.FirstAsync(u => u.Username == username && u.Password == password);

            return apiUser;
        }
    }
}
