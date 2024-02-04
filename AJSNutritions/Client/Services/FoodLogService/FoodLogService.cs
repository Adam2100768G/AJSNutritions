using System.Net.Http.Json;
using AJSNutritions.Shared;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace AJSNutritions.Client.Services.FoodLogService;

public class FoodLogService : IFoodLogService
{
	private readonly HttpClient _client;

	public FoodLogService(HttpClient client)
	{
		_client = client;
	}

	public async Task<List<FoodLog>> GetFoodLogs(int userId)
	{
		var response = await _client.GetAsync($"api/foodlog/all/{userId}");

		if (!response.IsSuccessStatusCode)
		{
			return new List<FoodLog>();
		}
		var data = await response.Content.ReadFromJsonAsync<List<FoodLog>>();

		return data ?? new List<FoodLog>();
	}

	public async Task<FoodLog?> GetFoodLogById(int id)
	{
		var response = await _client.GetAsync($"api/foodlog/{id}");
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		try
		{
			return await response.Content.ReadFromJsonAsync<FoodLog>();
		}
		catch (Exception e)
		{
			return null;
		}
	}

	public async Task<FoodLog?> CreateFoodLog(FoodLog foodLog)
	{
		var response = await _client.PostAsJsonAsync("api/foodlog", foodLog);
		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadFromJsonAsync<FoodLog>();
		}

		return null;
	}

	public async Task<FoodLog?> UpdateFoodLog(int id, FoodLog foodLog)
	{
		var response = await _client.PutAsJsonAsync($"api/foodlog/{id}", foodLog);
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		return await response.Content.ReadFromJsonAsync<FoodLog>();
	}

	public async Task DeleteFoodLog(int id)
	{
		await _client.DeleteAsync($"api/foodlog/{id}");
	}
}