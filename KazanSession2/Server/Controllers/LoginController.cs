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

        private string CreateJWT(Employee _employee)
        {
            var _secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hdC126eNHjD/hHC1vkI4hD8SYuawA9NoiqCFScAMsKU="));
            var _credential = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var _claims = new[]
            {
                new Claim(ClaimTypes.Name, _employee.Username),
                new Claim("Id", _employee.Id.ToString())
            };

            var _token = new JwtSecurityToken(issuer: "kinakolab.com", audience: "kinakolab.com", claims: _claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: _credential);
            return new JwtSecurityTokenHandler().WriteToken(_token);
        }

        [Route("api/[controller]")]
        public IActionResult Post(Employee _loginData)
        {
            Employee? _employee = db.Employees.FirstOrDefault(a => a.Username == _loginData.Username && a.Password == _loginData.Password);
            if (_employee != null) 
            {
                _employee.Password = CreateJWT(_employee);
                return Ok(_employee);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
