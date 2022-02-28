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

        public EmpController(IEmpService emp, ILogger<EmpController> logger, IDeptService dept)
        {
            this.emp = emp;
            this.logger = logger;
            this.dept = dept;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await emp.GetAll();
            logger.LogInformation("Get Employee Data...");
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await emp.GetById(id);
            logger.LogInformation("Get Employee Data...");
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmp([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var res = await emp.Create(employee);
                logger.LogInformation("Create New Employee...Controller");
                return Ok(res);
            }
            return BadRequest("Invalid Object...");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmp([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var res = await emp.Update(employee);
                logger.LogInformation("Update Employee...");
                return Ok(res);
            }
            return BadRequest("Invalid Object...");
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByExpression(string name)
        {
            var res = await emp.FindByCondition(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToListAsync();
            if (res.Count == 0) return NoContent();
            return Ok(res);
        }

        [HttpGet("deptlist")]
        public async Task<IActionResult> GetDepartment()
        {
            var res = await dept.List();
            logger.LogInformation("Get Dept list.");
            return Ok(res);
        }


        [HttpPost("RegDept")]
        public async Task<IActionResult> CreateDept(Department department)
        {
            var res = await dept.Create(department);
            logger.LogInformation("Create New Department...Controller");
            return Ok(res);
        }

        [HttpDelete("dept/{id:int}")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            logger.LogInformation("Delete Department...Controller");
            var res = await dept.Delete(id);
            if (res == 0)
            {
                return NotFound("Dept Id not found...");
            }
            return Ok(res);
        }

        [HttpGet("dept/{id:int}")]
        public async Task<IActionResult> GetDept(int id)
        {
            logger.LogInformation("Delete Department...Controller");
            var res = await dept.GetById(id);
            if (res == null)
            {
                return NotFound("Dept Id not found...");
            }
            return Ok(res);
        }

        [HttpPut("dept/Update")]
        public async Task<IActionResult> UpdateDept(Department deptObj)
        {
            logger.LogInformation("Update Department...Controller");
            var res = await dept.Update(deptObj);
            if (res == null)
            {
                return NotFound("Dept Id not found...");
            }
            return Ok(res);
        }
    }
}
