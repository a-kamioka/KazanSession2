using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KazanSession2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangedPartController : ControllerBase
    {
        private readonly DB db;
        public ChangedPartController(DB db) => this.db = db;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<ChangedPart> _changedParts)
        {
            _changedParts.ForEach(_part =>
            {
                db.ChangedParts.Add(_part);
            });
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
