using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KazanSession2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly DB db;
        public PartsController(DB db) => this.db = db;

        public IActionResult Get()
        {
            return Ok(db.Parts);
        }
    }
}
