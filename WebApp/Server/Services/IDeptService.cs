using WebApp.Shared.Models;

namespace WebApp.Server.Services
{
    public interface IDeptService
    {
        Task<IEnumerable<Department>> List();
        Task<Department> GetById(int id);
        Task<int> Create(Department department);
        Task<Department> Update(Department department);
        Task<int> Delete(int id);
    }
}
