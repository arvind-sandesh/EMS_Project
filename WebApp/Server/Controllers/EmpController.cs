using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Server.Services;

namespace WebApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpService emp;

        public EmpController(IEmpService emp)
        {
            this.emp = emp;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res= await emp.GetAll();
            return Ok(res);
        }
    }
}
