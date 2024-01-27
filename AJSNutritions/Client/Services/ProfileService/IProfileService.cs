using AJSNutritions.Shared;

namespace AJSNutritions.Client.Services.ProfileService;

public interface IProfileService
{
	Task<Profile?> GetByUserName(string id);

	Task Update(string UserName, Profile profile);
}