using System;
using EducalBack.Models;
using EducalBack.ViewModels.Courses;

namespace EducalBack.Services.Interfaces
{
	public interface ICourseService
	{
		Task<IEnumerable<Course>> GetAllAsync();
		Task<IEnumerable<CourseVM>> GetAllForAdminAsync();
		Task<Course> GetByIdAsync(int id);
		Task<Course> GetByIdWithAllDatasAsync(int id);
        Task CreateAsync(Course course);
		Task DeleteAsync(Course course);
		Task DeleteCourseImageAsync(MainAndDeleteCourseImageVM data);
        Task SetMainCourseImageAsync(MainAndDeleteCourseImageVM data);
		Task EditAsync(Course course,CourseEditVM editCourse);
		Task<List<Course>> GetAllCoursesById(int id);
    }
}

