using System;
namespace EducalBack.Models
{
	public class Course:BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public List<CourseImage> CourseImages { get; set; }


	}
}

