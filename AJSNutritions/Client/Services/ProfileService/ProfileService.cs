using System.Net.Http.Json;
using AJSNutritions.Shared;
using Microsoft.AspNetCore.Components;

namespace AJSNutritions.Client.Services.ProfileService;

public class ProfileService : IProfileService
{
	private readonly HttpClient _client;
	private readonly NavigationManager _navigationManager;

	public ProfileService(HttpClient client, NavigationManager navigationManager)
	{
		_client = client;
		_navigationManager = navigationManager;
	}

	public async Task<Profile?> GetByUserName(string id)
	{
		var result = await _client.GetAsync($"api/profile/{id}");
		if (result.IsSuccessStatusCode)
		{
			return await result.Content.ReadFromJsonAsync<Profile>();
		}

		return null;
	}

	public async Task Update(string UserName, Profile profile)
	{
		await _client.PutAsJsonAsync($"api/profile/{UserName}", profile);
		_navigationManager.NavigateTo("/profile");
	}

}