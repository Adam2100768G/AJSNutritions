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

	public List<FoodLogDto> FoodLogs { get; set; } = new();


	public async Task GetFoodLogs(string userId)
	{
		var result = await _httpClient.GetAsync($"api/foodlog/all/{userId}");
		if (result.IsSuccessStatusCode)
		{
			FoodLogs = await result.Content.ReadFromJsonAsync<List<FoodLogDto>>();
		}
	}

	public async Task<FoodLogDto?> GetFoodLogById(int id)
	{
		return await _httpClient.GetFromJsonAsync<FoodLogDto>($"api/foodlog/{id}");
	}

	public async Task<FoodLogDto?> CreateFoodLog(FoodLogDto foodLogDto)
	{
		var response = await _httpClient.PostAsJsonAsync("api/foodlog", foodLogDto);
		if (response.IsSuccessStatusCode)
		{
			var res = await response.Content.ReadFromJsonAsync<FoodLogDto>();

			FoodLogs.Add(res);

			return res;
		}
		else
		{
			throw new ApplicationException(await response.Content.ReadAsStringAsync());
		}
	}

	public async Task UpdateFoodLog(int id, FoodLogDto foodLogDto)
	{
		var response = await _httpClient.PutAsJsonAsync($"api/foodlog/{id}", foodLogDto);
		if (response.IsSuccessStatusCode)
		{
			var index = FoodLogs.FindIndex(f => f.Id == id);
			if (index != -1)
			{
				FoodLogs[index] = foodLogDto;
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