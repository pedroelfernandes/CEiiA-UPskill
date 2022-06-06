﻿using MainAPI.Data;
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
                return role;

            await _db.Roles.AddAsync(role);
            await _db.SaveChangesAsync();
            return role;
        }

        public async Task<Role> Get(int id)
        {
            Role? role;

            // get the role
            role = await _db.Roles.FindAsync(id);
            return role;
        }

        public async Task<Role> Edit(int id, string name, string description)
        {
            _db.Roles.Update(await Get(id)).Property(r => r.Name).CurrentValue = name;
            _db.Roles.Update(await Get(id)).Property(r => r.Description).CurrentValue = description;
            await _db.SaveChangesAsync();
            return await Get(id);
        }

        public async Task<bool> ChangeState(int id)
        {
            Role? role;

            role = await _db.Roles.FindAsync(id);

            if (role == null)
                return false;

            role.Active ^= true;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}