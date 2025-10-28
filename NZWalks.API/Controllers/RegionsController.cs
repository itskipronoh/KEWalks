using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET all regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await dbContext.Regions.ToListAsync();
            return Ok(regions);
        }

        // GET region by id
        // GET: /api/regions/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (region == null)
                return NotFound();

            return Ok(region);
        }
        [HttpPost]
        public async Task<IActionResult> AddRegion(Region region)
        {
            region.Id = Guid.NewGuid();
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRegionById), new { id = region.Id }, region);
        }
    }
}
