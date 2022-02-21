﻿using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using WebApp.Shared.Models;

namespace WebApp.Server.Services
{
    public class DeptService : IDeptService
    {
        private readonly AppDbContext db;
        public DeptService(AppDbContext db)
        {
            this.db = db;
        }
        public Task<int> Create(Department department)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> List()
        {
            return await db.Departments.ToListAsync();
        }

        public Task<Department> Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}