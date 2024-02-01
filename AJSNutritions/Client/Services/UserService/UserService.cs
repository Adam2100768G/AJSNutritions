using System.Net.Http.Json;
using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Client.Services.UserService;

public class UserService : IUserService
{
	private readonly HttpClient _client;

	public UserService(HttpClient client)
	{
		_client = client;
	}

	public List<User> Users { get; set; } = new();


	public async Task GetUsers()
	{
		var result = await _client.GetFromJsonAsync<List<User>>($"api/user");
		if (result is not null)
		{
			Users = result;
		}
	}

	public async Task<User?> GetByUserName(string userName)
	{
		var result = await _client.GetAsync($"api/user/name/{userName}");
		if (result.IsSuccessStatusCode)
		{
			return await result.Content.ReadFromJsonAsync<User>();
		}

		return null;
	}

	public async Task<User?> GetUserById(int id)
	{
		var result = await _client.GetAsync($"api/user/{id}");
		if (result.IsSuccessStatusCode)
		{
			return await result.Content.ReadFromJsonAsync<User>();
		}

		return null;
	}

	public async Task<User?> CreateUser(User user)
	{
		var response = await _client.PostAsJsonAsync("api/user", user);
		if (response.IsSuccessStatusCode)
		{
			var res = await response.Content.ReadFromJsonAsync<User>();

			Users.Add(res);

			return res;
		}

		return null;
	}

	public async Task UpdateUser(int id, User user)
	{
		await _client.PutAsJsonAsync($"api/user/{id}", user);
	}

	public async Task DeleteUser(int id)
	{
		await _client.DeleteAsync($"api/user/{id}");
	}
}