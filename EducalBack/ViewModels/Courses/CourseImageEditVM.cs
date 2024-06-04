using System;
namespace EducalBack.ViewModels.Courses
{
	public class CourseImageEditVM
	{
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Image { get; set; }

        public bool IsMain { get; set; }
    }
}

