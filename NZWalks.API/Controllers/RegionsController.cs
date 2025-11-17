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
        // UPDATE region
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id, Region updatedRegion)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRegion == null)
                return NotFound();
            // Update properties
            existingRegion.Name = updatedRegion.Name;
            existingRegion.Code = updatedRegion.Code;
            existingRegion.RegionImageUrl = updatedRegion.RegionImageUrl;
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
        // DELETE region
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRegion == null)
                return NotFound();
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
