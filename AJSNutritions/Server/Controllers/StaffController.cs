using AJSNutritions.Server.Services.StaffService;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AJSNutritions.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly IStaffService _staffService;

		public StaffController(IStaffService staffService)
		{
			_staffService = staffService;
		}

		// GET: api/<StaffController>
		[HttpGet]
		public async Task<List<Staff>> GetStaffs()
		{
			return await _staffService.GetStaffs();
		}

		// GET api/<StaffController>/5
		[HttpGet("{id}")]
		public async Task<Staff?> Get(int id)
		{
			return await _staffService.GetStaffById(id);
		}

		// POST api/<StaffController>
		[HttpPost]
		public async Task Post([FromBody] Staff value)
		{
			await _staffService.CreateStaff(value);
		}

		// PUT api/<StaffController>/5
		[HttpPut("{id}")]
		public async Task Put(int id, [FromBody] Staff value)
		{
			await _staffService.UpdateStaff(id, value);
		}

		// DELETE api/<StaffController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _staffService.DeleteStaff(id);
		}
	}
}