using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Server.Services;
using WebApp.Shared.Models;

namespace WebApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpService emp;
        private readonly ILogger<EmpController> logger;
        private readonly IDeptService dept;

        public EmpController(IEmpService emp,ILogger<EmpController> logger,IDeptService dept)
        {
            this.emp = emp;
            this.logger = logger;
            this.dept = dept;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res= await emp.GetAll();
            logger.LogInformation("Get Employee Data...");
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmp(Employee employee)
        {
            var res = await emp.Create(employee);
            logger.LogInformation("Create New Employee...Controller");
            return Ok(res);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByExpression(string name)
        {
            var res = await emp.FindByCondition(x=>x.FirstName.Contains(name) || x.LastName.Contains(name)).ToListAsync();
            logger.LogInformation("Get Employee from name...");
            return Ok(res);
        }

        [HttpGet("deptlist")]
        public async Task<IActionResult> GetDepartment()
        {
            var res = await dept.List();
            logger.LogInformation("Get Dept list.");
            return Ok(res);
        }
    }
}
