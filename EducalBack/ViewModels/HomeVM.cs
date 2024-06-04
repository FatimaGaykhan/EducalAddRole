using System;
using EducalBack.Models;

namespace EducalBack.ViewModels
{
	public class HomeVM
	{
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<Course> Courses { get; set; }
		public string UserFullName { get; set; }


	}
}

