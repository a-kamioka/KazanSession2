using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KazanSession2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly DB db;
        public PriorityController(DB db) => this.db = db;

        public IActionResult Get()
        {
            return Ok(db.Priorities);
        }
    }
}
