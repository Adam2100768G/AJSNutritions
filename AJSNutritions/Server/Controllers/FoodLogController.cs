﻿using AJSNutritions.Server.Services.FoodLogService;
using AJSNutritions.Shared.Domain;
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
	[HttpGet("all/{userName}")]
	public async Task<List<FoodLog>> GetFoodLogsForUser(string userName)
	{
		return await _foodLogService.GetFoodLogs(userName);
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
	public async Task Put(int id, [FromBody] FoodLog value)
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