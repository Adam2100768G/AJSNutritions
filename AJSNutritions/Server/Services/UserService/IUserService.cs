using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Server.Services.UserService
{
	// Server side CRUD interface for User
	public interface IUserService
	{
		Task<List<User>> GetUsers();

		Task<User?> GetUserById(int id);

		Task<User> CreateUser(User user);

		Task<User?> UpdateUser(int id, User user);

		Task<bool> DeleteUser(int id);
	}
}
