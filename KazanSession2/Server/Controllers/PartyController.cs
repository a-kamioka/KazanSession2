using KazanSession2.Shared;
using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KazanSession2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly DB db;
        public PartyController(DB db) => this.db = db;

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var list = db.Assets.Where(a => a.EmployeeId == id).Include(a => a.EmergencyMaintenances);
            return Ok(list.Select(a => new AssetList
            {
                Id = a.Id,
                AssetSn = a.AssetSn,
                AssetName = a.AssetName,
                EmendDate = a.EmergencyMaintenances.Max(b => b.EmendDate),
                ClosedNumber = a.EmergencyMaintenances.Count(b => b.EmendDate != null),
                EmNumber = a.EmergencyMaintenances.Count()
            }));
        }
    }
}
