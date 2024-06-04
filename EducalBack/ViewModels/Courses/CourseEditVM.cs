using System;
using System.ComponentModel.DataAnnotations;

namespace EducalBack.ViewModels.Courses
{
	public class CourseEditVM
	{

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }

        public int CategoryId { get; set; }

        public List<IFormFile> NewImages { get; set; }

        public List<CourseImageEditVM> ExistImages { get; set; }

    }
}

