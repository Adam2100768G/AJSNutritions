using AJSNutritions.Shared;

namespace AJSNutritions.Server.Services.ProfileService;

public interface IProfileService
{
	Task<Profile?> GetByUserName(string id);

	Task<Profile> UpdateProfile(string userName, Profile profile);
}