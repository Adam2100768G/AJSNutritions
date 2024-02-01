using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJSNutritions.Shared.Domain
{
	public class User : BaseDomainModel
	{
		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Address { get; set; }

		public int Gender { get; set; }

		public double Weight { get; set; }

		public int Height { get; set; }

		public double Bmi { get; set; }

		public string Allergies { get; set; }

		public string ActivityRate { get; set; }

		public string MedicalHistory { get; set; }

		public DateTime TargetDate { get; set; }

		public double TargetWeight { get; set; }

		public double TargetBmi { get; set; }
	}
}