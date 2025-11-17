using System;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DifficultyController : ControllerBase
{
	private readonly NZWalksDbContext dbContext;
	public DifficultyController(NZWalksDbContext dbContext)
	{
		this.dbContext = dbContext;
	}
	// GET all difficulties
	[HttpGet]
	public async Task<IActionResult> GetAllDifficulties()
	{
		var difficulties = await dbContext.Difficulties.ToListAsync();
		return Ok(difficulties);
	}
	// GET difficulty by id
	// GET: /api/difficulty/{id}
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetDifficultyById(Guid id)
	{
		var difficulty = await dbContext.Difficulties.FirstOrDefaultAsync(d => d.Id == id);
		if (difficulty == null)
			return NotFound();
		return Ok(difficulty);
	}
	// POST: /api/difficulty
	[HttpPost]
	public async Task<IActionResult> AddDifficulty(Difficulty difficulty)
	{
		difficulty.Id = Guid.NewGuid();
		await dbContext.Difficulties.AddAsync(difficulty);
		await dbContext.SaveChangesAsync();
		return CreatedAtAction(nameof(GetDifficultyById), new { id = difficulty.Id }, difficulty);
	}
	// PUT: /api/difficulty/{id}
	[HttpPut("{id:guid}")]
	public async Task<IActionResult> UpdateDifficulty(Guid id, Difficulty updatedDifficulty)
	{
		var existingDifficulty = await dbContext.Difficulties.FirstOrDefaultAsync(d => d.Id == id);
		if (existingDifficulty == null)
			return NotFound();
		// Update properties
		existingDifficulty.Name = updatedDifficulty.Name;
		await dbContext.SaveChangesAsync();
		return NoContent();
	}
	// DELETE: /api/difficulty/{id}
	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteDifficulty(Guid id)
	{
		var existingDifficulty = await dbContext.Difficulties.FirstOrDefaultAsync(d => d.Id == id);
		if (existingDifficulty == null)
			return NotFound();
		dbContext.Difficulties.Remove(existingDifficulty);
		await dbContext.SaveChangesAsync();
		return NoContent();
	}
}