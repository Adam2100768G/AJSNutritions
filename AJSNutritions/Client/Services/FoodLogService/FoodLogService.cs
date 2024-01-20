using System.Net.Http.Json;
using AJSNutritions.Shared;
using Microsoft.AspNetCore.Components;

namespace AJSNutritions.Client.Services.FoodLogService;

public class FoodLogService : IFoodLogService
{
	private readonly HttpClient _httpClient;

	public FoodLogService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public List<FoodLog> FoodLogs { get; set; } = new();


	public async Task GetFoodLogs()
	{
		var result = await _httpClient.GetAsync("api/foodlog");
		if (result.IsSuccessStatusCode)
		{
			FoodLogs = await result.Content.ReadFromJsonAsync<List<FoodLog>>();
		}
	}

	public async Task<FoodLog?> GetFoodLogById(int id)
	{
		return await _httpClient.GetFromJsonAsync<FoodLog>($"api/foodlog/{id}");
	}

	public async Task CreateFoodLog(FoodLog foodLog)
	{
		var response = await _httpClient.PostAsJsonAsync("api/foodlog", foodLog);
		if (response.IsSuccessStatusCode)
		{
			FoodLogs.Add(foodLog);
		}
		else
		{
			throw new ApplicationException(await response.Content.ReadAsStringAsync());
		}
	}

	public async Task UpdateFoodLog(int id, FoodLog foodLog)
	{
		var response = await _httpClient.PutAsJsonAsync($"api/foodlog/{id}", foodLog);
		if (response.IsSuccessStatusCode)
		{
			var index = FoodLogs.FindIndex(f => f.Id == id);
			if (index != -1)
			{
				FoodLogs[index] = foodLog;
			}
		}
		else
		{
			throw new ApplicationException(await response.Content.ReadAsStringAsync());
		}
	}

	public async Task DeleteFoodLog(int id)
	{
		var response = await _httpClient.DeleteAsync($"api/foodlog/{id}");
		if (response.IsSuccessStatusCode)
		{
			FoodLogs.Remove(FoodLogs.Find(f => f.Id == id));
		}
		else
		{
			throw new ApplicationException(await response.Content.ReadAsStringAsync());
		}
	}
}