using System.Net.Http.Json;

namespace AJSNutritions.Client.Services.UserService;

public class UserService : IUserService
{
	private readonly HttpClient _client;
	
	public UserService(HttpClient client)
	{
		_client = client;
	}

	public List<AJSNutritions.Shared.Domain.User> Users { get; set; } = new();


	public async Task GetUsers()
	{
		var result = await _client.GetFromJsonAsync<List<AJSNutritions.Shared.Domain.User>>($"api/user");
		if (result is not null)
		{
			Users = result;
		}
	}

	public async Task<AJSNutritions.Shared.Domain.User?> GetUserById(int id)
	{
		var response = await _client.GetAsync($"api/user/{id}");
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		try
		{
			// Check if response has content
			return await response.Content.ReadFromJsonAsync<AJSNutritions.Shared.Domain.User>();
		}
		catch (Exception e)
		{
			return null;
		}
		
	}

	public async Task<AJSNutritions.Shared.Domain.User?> CreateUser(AJSNutritions.Shared.Domain.User user)
	{
		var response = await _client.PostAsJsonAsync("api/user", user);
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}
		var created = await response.Content.ReadFromJsonAsync<AJSNutritions.Shared.Domain.User>();

		if (created is null)
		{
			return null;
		}

		Users.Add(created);
		return created;
	}

	public async Task<AJSNutritions.Shared.Domain.User?> UpdateUser(int id, AJSNutritions.Shared.Domain.User user)
	{
		
		var response = await _client.PutAsJsonAsync($"api/user/{id}", user);
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}
		var updated = await response.Content.ReadFromJsonAsync<AJSNutritions.Shared.Domain.User>();
		if (updated is null)
		{
			return null;
		}

		var index = Users.FindIndex(u => u.Id == id);
		if (index != -1)
		{
			Users[index] = updated;
		}
		else
		{
			Users.Add(updated);
		}

		return updated;

	}

	public async Task DeleteUser(int id)
	{
		await _client.DeleteAsync($"api/user/{id}");
	}
}