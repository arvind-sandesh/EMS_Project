using DataAccess.Data;
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
        public async Task<int> Create(Department department)
        {
            int res = 0;
            if (department != null)
            {
                await db.Departments.AddAsync(department);
                res = await db.SaveChangesAsync();
            }
            return res;
        }

        public async Task<int> Delete(int id)
        {
            int res = 0;
            var dept = db.Departments.Find(id);
            if(dept != null)
            {
                db.Departments.Remove(dept);
              res= await db.SaveChangesAsync();
            } 
            return (int)res;
        }

        public async Task<Department> GetById(int id)
        {
            return await db.Departments.FindAsync(id);
        }

        public async Task<IEnumerable<Department>> List()
        {
            return await db.Departments.ToListAsync();
        }

        public async Task<Department> Update(Department department)
        {
            if (department != null)
            {
                db.Entry<Department>(department).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return department;
            }
            return department;
        }
    }
}
