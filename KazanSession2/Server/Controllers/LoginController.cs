using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KazanSession2.Server.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DB db;
        public LoginController(DB db) => this.db = db;

        private string CreateJWT(Employee employee)
        {
            var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hdC126eNHjD/hHC1vkI4hD8SYuawA9NoiqCFScAMsKU="));
            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, employee.Username),
                new Claim("Id", employee.Id.ToString())
            };

            var token = new JwtSecurityToken(issuer: "kinakolab.com", audience: "kinakolab.com", claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Route("api/[controller]")]
        public IActionResult Post(Employee loginData)
        {
            Employee? employee = db.Employees.FirstOrDefault(a => a.Username == loginData.Username && a.Password == loginData.Password);
            if (employee != null) 
            {
                employee.Password = CreateJWT(employee);
                return Ok(employee);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
