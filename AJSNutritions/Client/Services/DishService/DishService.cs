using System.Net.Http.Json;
using AJSNutritions.Shared;
using Microsoft.AspNetCore.Components;

namespace AJSNutritions.Client.Services.DishService;

public class DishService: IDishService
{
	private readonly HttpClient _client;
	private readonly NavigationManager _navigationManager;

	public DishService(HttpClient client, NavigationManager navigationManager)
	{
		_client = client;
		_navigationManager = navigationManager;
	}
	public List<Dish> Dishes { get; set; } = new List<Dish>();

	public async Task GetDishes()
	{
		var result = await _client.GetFromJsonAsync<List<Dish>>("api/dish");
		if (result is not null)
		{
			Dishes = result;
		}
	}

	public async Task<Dish?> GetDishById(int id)
	{
		var result = await _client.GetAsync($"api/dish/{id}");
		if (result.IsSuccessStatusCode)
		{
			return await result.Content.ReadFromJsonAsync<Dish>();
		}

		return null;
	}

	public async Task CreateDish(Dish dish)
	{
		await _client.PostAsJsonAsync("api/dish", dish);
		_navigationManager.NavigateTo("/dishes");
	}

	public async Task UpdateDish(int id, Dish dish)
	{
		await _client.PutAsJsonAsync($"api/dish/{id}", dish);
		_navigationManager.NavigateTo("/dishes");
	}

	public async Task DeleteDish(int id)
	{
		await _client.DeleteAsync($"api/dish/{id}");
		_navigationManager.NavigateTo("/dishes");
	}
}