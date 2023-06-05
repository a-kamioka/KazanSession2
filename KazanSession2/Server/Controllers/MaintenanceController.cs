using KazanSession2.Shared;
using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;

namespace KazanSession2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaintenanceController : ControllerBase
    {
        private readonly DB db;
        public MaintenanceController(DB db) => this.db = db;

        [HttpGet]
        public IActionResult Get()
        {
            string _token = "";
            StringValues _values;
            Request.Headers.TryGetValue("Authorization", out _values);
            foreach (var _value in _values)
            {
                _token += _value + " ";
            }
            var _jwt = new JwtSecurityTokenHandler().ReadJwtToken(_token.Split(' ')[1]);
            long _id = Int64.Parse(_jwt.Claims.First(c => c.Type == "Id").Value);
            Employee _employee = db.Employees.Find(_id);
            if (_employee.IsAdmin != true) return Forbid();

            return Ok(db.EmergencyMaintenances.Include(a => a.Asset).Where(a => a.EmendDate == null).OrderByDescending(a => a.PriorityId).OrderBy(a => a.EmreportDate).Select(a => new EMList
            {
                Id = a.Id,
                AssetSn = a.Asset.AssetSn,
                AssetName = a.Asset.AssetName,
                EmRequestDate = a.EmreportDate,
                FullName = a.Asset.Employee.FirstName + " " + a.Asset.Employee.LastName,
                Department = a.Asset.DepartmentLocation.Department.Name
            }));
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(long id)
        {
            return Ok(db.EmergencyMaintenances.Include(a => a.Asset).Select(a => new SelectedAsset
            {
                Id = a.Id,
                AssetSn = a.Asset.AssetSn,
                AssetName = a.Asset.AssetName,
                DepartmentName = a.Asset.DepartmentLocation.Department.Name
            }).Single(a => a.Id == id));
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromBody] EmergencyMaintenance _em)
        {
            // db.Entry(_em).State = EntityState.Modified;
            EmergencyMaintenance? _target = db.EmergencyMaintenances.Find(_em.Id);
            _target.EmstartDate = _em.EmstartDate;
            _target.EmendDate = _em.EmendDate;
            _target.EmtechnicianNote = _em.EmtechnicianNote;
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
