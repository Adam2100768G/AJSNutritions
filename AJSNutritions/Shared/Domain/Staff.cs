using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJSNutritions.Shared.Domain
{
	public class Staff : BaseDomainModel
	{
		public string name { get; set; }

		public string email { get; set; }

		public DateTime dateofbirth { get; set; }

		public string password { get; set; }

		public string gender { get; set; }

		public string address { get; set; }

		public int phone { get; set; }

		public string stafftype { get; set; }

	}
}
