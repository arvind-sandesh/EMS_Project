using System.Linq.Expressions;
using WebApp.Shared.Models;

namespace WebApp.Server.Services
{
    public class EmpServiceMock : IEmpService
    {
        public Task<int> Create(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAll()
        {
            return _employees;
           
        }

        public Task<Employee> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> FindByCondition(Expression<Func<Employee, bool>> expression)
        {
            throw new NotImplementedException();
        }

        private List<Employee> _employees = new List<Employee>()
        {
            new Employee(){ EmployeeId = 1, DateOfBirth = DateTime.Now.AddYears(-20), DepartmentId=1, EmailId="abc@gmail.com", FirstName="Abc", LastName="Xyz", Gender="Male", MobileNumber="8182823390", Department=new Department{ DepartmentId=1, DepartmentName="DEPT1" } },
            new Employee(){ EmployeeId = 2, DateOfBirth = DateTime.Now.AddYears(-25), DepartmentId=1, EmailId="xyz@gmail.com", FirstName="AAAA", LastName="BBB", Gender="Female", MobileNumber="9616432112", Department=new Department{ DepartmentId=1, DepartmentName="DEPT1" } }
        };
    }
}
