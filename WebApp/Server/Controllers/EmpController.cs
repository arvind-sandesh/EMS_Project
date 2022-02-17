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
        private readonly ILogger<EmpController> logger;

        public EmpController(IEmpService emp,ILogger<EmpController> logger)
        {
            this.emp = emp;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res= await emp.GetAll();
            logger.LogInformation("Get Employee Data...");
            return Ok(res);
        }
    }
}
