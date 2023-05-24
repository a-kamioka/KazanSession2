using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KazanSession2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DB db;
        public LoginController(DB db) => this.db = db;

        public IActionResult Post(Employee _loginData)
        {
            Employee? employee = db.Employees.FirstOrDefault(a => a.Username == _loginData.Username && a.Password == _loginData.Password);
            if (employee == null) 
            {
                return Unauthorized();
            }
            else
            {
                return Ok(employee);
            }
        }
    }
}
