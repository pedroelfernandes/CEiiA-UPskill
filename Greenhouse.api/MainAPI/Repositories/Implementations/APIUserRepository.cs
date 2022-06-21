using MainAPI.Data;
using MainAPI.Helpers.Implementations;
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

            //hash password before storing user
            //apiUser.Password = PwdEncryptor.Encrypt(apiUser.Password);

            await _db.APIUsers.AddAsync(apiUser);
            await _db.SaveChangesAsync();

            apiUser.Role = await _roleRepository.GetRole(apiUser.RoleId);

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


        public async Task<bool> Authorized(string username, string password)
        {
            //hash password before checking with database database
            //password = PwdEncryptor.Encrypt(password);

            APIUser apiUser = await _db.APIUsers.FirstAsync(u => u.Username == username && u.Password == password);

            if (apiUser != null)
                return true;

            return false;
        }
    }
}
