using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Shared.Models;

namespace WebApp.Server.Services
{
    public class EmpService : IEmpService
    {
        private readonly AppDbContext db;
        private readonly ILogger<EmpService> logger;
        public EmpService(AppDbContext db, ILogger<EmpService> logger)
        {
            this.db = db;
            this.logger = logger;
        }
        public async Task<int> Create(Employee employee)
        {
            int res = 0;
            if (employee != null)
            {
                await db.Employees.AddAsync(employee);
                res=await db.SaveChangesAsync();                
            }
            return res;
        }
        public async Task Delete(int id)
        {
            var emp = await db.Employees.SingleOrDefaultAsync(x => x.EmployeeId == id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                await db.SaveChangesAsync();
            }
        }
        public IQueryable<Employee> FindByCondition(Expression<Func<Employee, bool>> expression)
        {
            return this.db.Set<Employee>().Where(expression).AsNoTracking();
        }
        public async Task<List<Employee>> GetAll()
        {
            return await db.Employees.Include(x=>x.Department).ToListAsync();
        }
        public async Task<Employee> GetById(int id)
        {
            var emp=await db.Employees.SingleOrDefaultAsync(x=>x.EmployeeId==id);
            return emp;
        }
        public async Task<Employee> Update(Employee employee)
        {            
           Employee emp =await db.Employees.FindAsync(employee.EmployeeId);
            if(emp != null)
            {
                emp = employee;
                db.SaveChanges();
            }
            return emp;
        }
    }
}
