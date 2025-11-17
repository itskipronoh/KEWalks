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
	[ApiController]
	[Route("api/[controller]")]
	public class WalksController : ControllerBase
	{
		private readonly NZWalksDbContext nZWalksDbContext;
		public WalksController(NZWalksDbContext nZWalksDbContext)
		{
			this.nZWalksDbContext = nZWalksDbContext;
		}
		// GET all walks
		[HttpGet]
		public async Task<IActionResult> GetAllWalks()
		{
			var walks = await nZWalksDbContext.Walks
				.Include(w => w.Region)
				.Include(w => w.Difficulty)
				.ToListAsync();
			return Ok(walks);
		}
		// GET walk by id
		[HttpGet]
		[Route("{id:guid}")]
		[ActionName("GetWalkById")]
		public async Task<IActionResult> GetWalkById(Guid id)
		{
			var walk = await nZWalksDbContext.Walks
				.Include(w => w.Region)
				.Include(w => w.Difficulty)
				.FirstOrDefaultAsync(w => w.Id == id);
			if (walk == null)
			{
				return NotFound();
			}
			return Ok(walk);
		}
		// POST a walk
		[HttpPost]
		public async Task<IActionResult> AddWalk(Walk walk)
		{
			walk.Id = Guid.NewGuid();
			await nZWalksDbContext.Walks.AddAsync(walk);
			await nZWalksDbContext.SaveChangesAsync();
			return CreatedAtAction(nameof(GetWalkById), new { id = walk.Id }, walk);
		}
		// PUT update a walk
		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateWalk(Guid id, Walk updatedWalk)
		{
			var existingWalk = await nZWalksDbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
			if (existingWalk == null)
			{
				return NotFound();
			}
			// Update properties
			existingWalk.Name = updatedWalk.Name;
			existingWalk.Description = updatedWalk.Description;
			existingWalk.LengthInKm = updatedWalk.LengthInKm;
			existingWalk.WalkImageUrl = updatedWalk.WalkImageUrl;
			existingWalk.RegionId = updatedWalk.RegionId;
			existingWalk.DifficultyId = updatedWalk.DifficultyId;
			await nZWalksDbContext.SaveChangesAsync();
			return Ok(existingWalk);
		}
		// DELETE a walk
		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> DeleteWalk(Guid id)
		{
			var existingWalk = await nZWalksDbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
			if (existingWalk == null)
			{
				return NotFound();
			}
			nZWalksDbContext.Walks.Remove(existingWalk);
			await nZWalksDbContext.SaveChangesAsync();
			return NoContent();
		}
	}
}