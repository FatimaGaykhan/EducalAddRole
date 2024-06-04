using System;
using Microsoft.AspNetCore.Identity;

namespace EducalBack.Models
{
	public class AppUser:IdentityUser
	{
		public string FullName { get; set; }
	}
}

