using KazanSession2.Shared;
using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KazanSession2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly DB db;
        public MaintenanceController(DB db) => this.db = db;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.EmergencyMaintenances.Include(a => a.Asset).Where(a => a.EmendDate.HasValue).OrderByDescending(a => a.PriorityId).Select(a => new EMList
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
            })).Single(a => a.Id == id);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
