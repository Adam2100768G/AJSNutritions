using AJSNutritions.Server.Services.DishService;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AJSNutritions.Server.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class DishController : ControllerBase
	{
		private readonly IDishService _dishService;

		public DishController(IDishService dishService)
		{
			_dishService = dishService;
		}

		// GET: api/<DishController>
		[HttpGet]
		public async Task<List<Dish>> GetDishes()
		{
			return await _dishService.GetDishes();
		}

		// GET api/<DishController>/5
		[HttpGet("{id}")]
		public async Task<Dish?> Get(int id)
		{
			return await _dishService.GetDishById(id);
		}

		// POST api/<DishController>
		[HttpPost]
		public async Task Post([FromBody] Dish value)
		{
			await _dishService.CreateDish(value);
		}

		// PUT api/<DishController>/5
		[HttpPut("{id}")]
		public async Task Put(int id, [FromBody] Dish value)
		{
			await _dishService.UpdateDish(id, value);
		}

		// DELETE api/<DishController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _dishService.DeleteDish(id);
		}
	}
}
