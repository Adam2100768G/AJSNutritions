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
		return await _client.GetFromJsonAsync<Staff>($"api/staff/{id}");
	}

	public async Task<Staff?> CreateStaff(Staff staff)
	{
		var response = await _client.PostAsJsonAsync("api/staff", staff);
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}
		var created = await response.Content.ReadFromJsonAsync<Staff>();
		if (created is null)
		{
			return null;
		}
		
		Staffs.Add(created);
		return created;
	}

	public async Task<Staff?> UpdateStaff(int id, Staff staff)
	{
		var response = await _client.PutAsJsonAsync($"api/staff/{id}", staff);
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}
		var updated = await response.Content.ReadFromJsonAsync<Staff>();
		if (updated is null)
		{
			return null;
		}

		var index = Staffs.FindIndex(s => s.Id == id);
		if (index != -1)
		{
			Staffs[index] = updated;
		}
		else
		{
			Staffs.Add(updated);
		}

		return updated;

	}

	public async Task DeleteStaff(int id)
	{
		await _client.DeleteAsync($"api/staff/{id}");
	}
}