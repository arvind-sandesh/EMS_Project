using System.Linq.Expressions;
using WebApp.Shared.Models;

namespace WebApp.Server.Services
{
    public interface IEmpService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<int> Create(Employee employee);
        Task<Employee> Update(Employee employee);
        Task Delete(int id);
        IQueryable<Employee> FindByCondition(Expression<Func<Employee, bool>> expression);
        
    }
}
