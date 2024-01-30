using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJSNutritions.Shared
{
	public class User
	{
		public string? useremail { get; set; }
		public DateTime dateofbirth { get; set; }
		public string username { get; set; }
		public string address { get; set; }
		public int weight { get; set; }
		public int bmi { get; set; }
		public int height { get; set; }
		public string gender { get; set; }
		public string? activityrate { get; set; }
		public string? medicalhistory { get; set; }
		public string? targetdate { get; set; }
		public string? caloriesneeded { get; set;}
		public string? deficitcalories {  get; set; }
		public string? allergy { get; set; }
		public string? targetweight { get; set; }
		public string? userpassword { get; set; }

	}
}
