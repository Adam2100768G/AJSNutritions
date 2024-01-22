using AJSNutritions.Server.Services.FoodLogService;
using AJSNutritions.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AJSNutritions.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodLogController : ControllerBase
{
	private readonly IFoodLogService _foodLogService;

	public FoodLogController(IFoodLogService foodLogService)
	{
		_foodLogService = foodLogService;
	}

	// This version gets all food logs for a user
	[HttpGet("all/{id}")]
	public async Task<List<FoodLogDto>> GetFoodLogsForUser(string id)
	{
		return await _foodLogService.GetFoodLogs(id);
	}

	// GET api/<FoodLogController>/5
	[HttpGet("{id}")]
	public async Task<FoodLogDto?> GetFoodLogById(int id)
	{
		return await _foodLogService.GetFoodLogById(id);
	}

	// POST api/<FoodLogController>
	[HttpPost]
	public async Task<FoodLogDto?> Post([FromBody] FoodLogDto value)
	{
		return await _foodLogService.CreateFoodLog(value);
	}

	// PUT api/<FoodLogController>/5
	[HttpPut("{id}")]
	public async Task Put(int id, [FromBody] FoodLogDto value)
	{
		await _foodLogService.UpdateFoodLog(id, value);
	}

	// DELETE api/<FoodLogController>/5
	[HttpDelete("{id}")]
	public async Task Delete(int id)
	{
		await _foodLogService.DeleteFoodLog(id);
	}
	
}