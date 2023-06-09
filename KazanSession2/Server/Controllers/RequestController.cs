﻿using KazanSession2.Shared;
using KazanSession2.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KazanSession2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestController : ControllerBase
    {
        private readonly DB db;
        public RequestController(DB db) => this.db = db;

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var list = db.Assets.Include(a => a.DepartmentLocation).ThenInclude(a => a.Department);
            return Ok(list.Select(a => new SelectedAsset
            {
                Id = a.Id,
                AssetSn = a.AssetSn,
                AssetName = a.AssetName,
                DepartmentName = a.DepartmentLocation.Department.Name
            }).Single(a => a.Id == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmergencyMaintenance em)
        {
            db.EmergencyMaintenances.Add(em);
            db.SaveChanges();
            return Ok();
        }
    }
}
