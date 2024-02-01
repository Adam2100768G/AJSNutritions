using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Client.Services.UserService
{
    public interface IUserService
	{
		List<User> Users { get; set; }

		Task GetUsers();

		Task<User?> GetByUserName(string userName);

		Task<User?> GetUserById(int id);

		Task<User?> CreateUser(User user);

		Task UpdateUser(int id, User user);

		Task DeleteUser(int id);
	}
}
