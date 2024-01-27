using AJSNutritions.Server.Services.ProfileService;
using AJSNutritions.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AJSNutritions.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : ControllerBase
	{
		private readonly IProfileService _profileService;

		public ProfileController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		[HttpGet("{id}")]
		public async Task<Profile?> Get(string id)
		{
			return await _profileService.GetByUserName(id);
		}

		[HttpPut("{userName}")]
		public async Task Put(string userName, [FromBody] Profile value)
		{
			await _profileService.UpdateProfile(userName, value);
		}
	}
}