using System.Net.Http.Json;
using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Client.Services.StaffService;

public class StaffService : IStaffService
{
	private readonly HttpClient _client;

	public StaffService(HttpClient client)
	{
		_client = client;
	}

	public List<Staff> Staffs { get; set; } = new();


	public async Task GetStaffs()
	{
		var result = await _client.GetFromJsonAsync<List<Staff>>($"api/staff");
		if (result is not null)
		{
			Staffs = result;
		}
	}

	public async Task<Staff?> GetStaffById(int id)
	{
		var result = await _client.GetAsync($"api/staff/{id}");
		if (result.IsSuccessStatusCode)
		{
			return await result.Content.ReadFromJsonAsync<Staff>();
		}

		return null;
	}

	public async Task<Staff?> CreateStaff(Staff staff)
	{
		var response = await _client.PostAsJsonAsync("api/staff", staff);
		if (response.IsSuccessStatusCode)
		{
			var res = await response.Content.ReadFromJsonAsync<Staff>();

			Staffs.Add(res);

			return res;
		}

		return null;
	}

	public async Task UpdateStaff(int id, Staff staff)
	{
		await _client.PutAsJsonAsync($"api/staff/{id}", staff);
	}

	public async Task DeleteStaff(int id)
	{
		await _client.DeleteAsync($"api/staff/{id}");
	}
}