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

	public List<FoodLog> FoodLogs { get; set; } = new();


	public async Task GetFoodLogs(string userName)
	{
		var result = await _client.GetFromJsonAsync<List<FoodLog>>($"api/foodlog/all/{userName}");
		if (result is not null)
		{
			FoodLogs = result;
		}
	}

	public async Task<FoodLog?> GetFoodLogById(int id)
	{
		return await _client.GetFromJsonAsync<FoodLog>($"api/foodlog/{id}");
	}

	public async Task<FoodLog?> CreateFoodLog(FoodLog foodLog)
	{
		var response = await _client.PostAsJsonAsync("api/foodlog", foodLog);
		if (response.IsSuccessStatusCode)
		{
			var res = await response.Content.ReadFromJsonAsync<FoodLog>();

			FoodLogs.Add(res);

			return res;
		}

		return null;
	}

	public async Task UpdateFoodLog(int id, FoodLog foodLog)
	{
		var response = await _client.PutAsJsonAsync($"api/foodlog/{id}", foodLog);
		if (response.IsSuccessStatusCode)
		{
			var index = FoodLogs.FindIndex(f => f.Id == id);
			if (index != -1)
			{
				FoodLogs[index] = foodLog;
			}
		}
	}

	public async Task DeleteFoodLog(int id)
	{
		var response = await _client.DeleteAsync($"api/foodlog/{id}");
		if (response.IsSuccessStatusCode)
		{
			FoodLogs.Remove(FoodLogs.Find(f => f.Id == id));
		}
	}
}