using AJSNutritions.Server.Models;
using AJSNutritions.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace AJSNutritions.Server.Services.ProfileService;

public class ProfileService : IProfileService
{
	private readonly UserManager<ApplicationUser> _userManager;

	public ProfileService(UserManager<ApplicationUser> userManager)
	{
		_userManager = userManager;
	}

	public async Task<Profile?> GetByUserName(string id)
	{
		var user = await _userManager.FindByNameAsync(id);

		if (user == null)
		{
			return null;
		}

		return new Profile
		{
			UserName = user.UserName,
			DateOfBirth = user.DateOfBirth,
			Address = user.Address,
			Gender = user.Gender,
			Weight = user.Weight ,
			Height = user.Height,
			Bmi = CalculateBmi(user.Weight, user.Height),
			Allergies = user.Allergies,
			ActivityRate = user.ActivityRate,
			MedicalHistory = user.MedicalHistory,
			TargetMonth = user.TargetMonth,
			TargetYear = user.TargetYear,
			TargetWeight = user.TargetWeight,
			TargetBmi = user.TargetBmi
		};
	}

	public async Task<Profile> UpdateProfile(string userName, Profile profile)
	{
		var toUpdate = await _userManager.FindByNameAsync(userName);
		if (toUpdate == null)
		{
			return null;
		}

		toUpdate.DateOfBirth = profile.DateOfBirth;
		toUpdate.Address = profile.Address;
		toUpdate.Gender = profile.Gender;
		toUpdate.Weight = profile.Weight;
		toUpdate.Height = profile.Height;
		toUpdate.Bmi = CalculateBmi(profile.Weight, profile.Height);
		toUpdate.Allergies = profile.Allergies;
		toUpdate.ActivityRate = profile.ActivityRate;
		toUpdate.MedicalHistory = profile.MedicalHistory;
		toUpdate.TargetMonth = profile.TargetMonth;
		toUpdate.TargetYear = profile.TargetYear;
		toUpdate.TargetWeight = profile.TargetWeight;
		toUpdate.TargetBmi = profile.TargetBmi;

		await _userManager.UpdateAsync(toUpdate);

		return profile;
	}

	private double CalculateBmi(double weight, int height)
	{
		if (weight > 0 && height > 0)
		{
			// height is in cm, so convert to m
			double heightcm = height / 100.0;


			return Math.Round(weight / (heightcm * heightcm), 2);
		}
		
		return 0;
	}
}