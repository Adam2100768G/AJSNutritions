using AJSNutritions.Server.Services.UserService;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AJSNutritions.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		// GET: api/<UserController>
		[HttpGet]
		public async Task<List<User>> GetUsers()
		{
			return await _userService.GetUsers();
		}

		// GET api/<UserController>/5
		[HttpGet("name/{userName}")]
		public async Task<User?> GetByUserName(string userName)
		{
			return await _userService.GetByUserName(userName);
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public async Task<User?> Get(int id)
		{
			return await _userService.GetUserById(id);
		}

		// POST api/<UserController>
		[HttpPost]
		public async Task Post([FromBody] User value)
		{
			await _userService.CreateUser(value);
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public async Task Put(int id, [FromBody] User value)
		{
			await _userService.UpdateUser(id, value);
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _userService.DeleteUser(id);
		}
	}
}
