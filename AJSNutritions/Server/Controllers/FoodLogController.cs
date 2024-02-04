using AJSNutritions.Server.Services.FoodLogService;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AJSNutritions.Server.Controllers;

// Server side CRUD REST controller for FoodLog
[Route("api/[controller]")]
[ApiController]
public class FoodLogController : ControllerBase
{
	private readonly IFoodLogService _foodLogService;

	public FoodLogController(IFoodLogService foodLogService)
	{
		_foodLogService = foodLogService;
	}

	// This version gets all food logs for a user because food logs have User as the FK
	[HttpGet("all/{userId}")]
	public async Task<List<FoodLog>> GetFoodLogsForUser(int userId)
	{
		return await _foodLogService.GetFoodLogs(userId);
	}


	// GET api/<FoodLogController>/5
	[HttpGet("{id}")]
	public async Task<FoodLog?> GetFoodLogById(int id)
	{
		return await _foodLogService.GetFoodLogById(id);
	}

	// POST api/<FoodLogController>
	[HttpPost]
	public async Task<FoodLog?> Post([FromBody] FoodLog value)
	{
		return await _foodLogService.CreateFoodLog(value);
	}

	// PUT api/<FoodLogController>/5
	[HttpPut("{id}")]
	public async Task<FoodLog?> Put(int id, [FromBody] FoodLog value)
	{
		return await _foodLogService.UpdateFoodLog(id, value);
	}

	// DELETE api/<FoodLogController>/5
	[HttpDelete("{id}")]
	public async Task Delete(int id)
	{
		await _foodLogService.DeleteFoodLog(id);
	}
	
}