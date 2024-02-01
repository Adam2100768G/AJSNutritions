﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJSNutritions.Shared.Domain
{
	public class Staff : BaseDomainModel
	{
		public string Name { get; set; }

		public string Email { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Password { get; set; }

		public string Gender { get; set; }

		public string Address { get; set; }

		public int Phone { get; set; }

		public string StaffType { get; set; }

	}
}
