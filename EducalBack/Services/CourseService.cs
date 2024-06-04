using System;
using EducalBack.Data;
using EducalBack.Helpers.Extensions;
using EducalBack.Models;
using EducalBack.Services.Interfaces;
using EducalBack.ViewModels.Courses;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EducalBack.Services
{
	public class CourseService:ICourseService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


		public CourseService(AppDbContext context,
                            IWebHostEnvironment env)
		{
            _context = context;
            _env = env;
		}

        public async Task CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Course course)
        {
             _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseImageAsync(MainAndDeleteCourseImageVM data)
        {
            var course = await _context.Courses.Where(m => m.Id == data.CourseId).Include(m=>m.CourseImages).FirstOrDefaultAsync();

            var courseImage = course.CourseImages.FirstOrDefault(m=>m.Id==data.ImageId);

            _context.CourseImages.Remove(courseImage);
            await _context.SaveChangesAsync();

            string path = _env.GenerateFilePath("assets/img",courseImage.Name);

            path.DeleteFileFromLocal();
        }

        public async Task EditAsync(Course course, CourseEditVM editCourse)
        {
            List<CourseImage> images = new();

            if (editCourse.NewImages != null)
            {
                foreach (var item in editCourse.NewImages)
                {
                    string fileName = $"{Guid.NewGuid()}-{item.FileName}";

                    string path = _env.GenerateFilePath("assets/img", fileName);
                    await item.SaveFileToLocalAsync(path);
                    images.Add(new CourseImage { Name = fileName });
                }

                course.CourseImages.AddRange(images);

            }





            course.Name = editCourse.Name;
            course.Description = editCourse.Description;
            course.CategoryId = editCourse.CategoryId;
            course.Price = decimal.Parse(editCourse.Price.Replace(".", ","));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(m => m.Category)
                                         .Include(m => m.CourseImages).ToListAsync();
        }

        public async Task<IEnumerable<CourseVM>> GetAllForAdminAsync()
        {
            IEnumerable<Course> courses= await _context.Courses.Include(m => m.Category)
                                         .Include(m => m.CourseImages).ToListAsync();

            return courses.Select(m => new CourseVM
            {
                Id=m.Id,
                Name=m.Name,
                CategoryName=m.Category.Name,
                Description=m.Description,
                MainImage=m.CourseImages.FirstOrDefault(m => m.IsMain)?.Name,
                Price=m.Price
            });
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<List<Course>> GetAllCoursesById(int id)
        {
            return await _context.Courses.Where(m=>m.CategoryId==id)
                .ToListAsync();
        }

        public async Task<Course> GetByIdWithAllDatasAsync(int id)
        {
            return await _context.Courses.Where(m => m.Id == id)
                                          .Include(m => m.Category)
                                          .Include(m => m.CourseImages)
                                          .FirstOrDefaultAsync();
        }

        public async Task SetMainCourseImageAsync(MainAndDeleteCourseImageVM data)
        {
            var course = await _context.Courses.Where(m => m.Id == data.CourseId).Include(m => m.CourseImages).FirstOrDefaultAsync();

            var courseImage = course.CourseImages.FirstOrDefault(m => m.Id == data.ImageId);

            if (course.CourseImages.Any(m => m.IsMain))
            {
                course.CourseImages.FirstOrDefault(m => m.IsMain).IsMain = false;
            }

            courseImage.IsMain = true;

            await _context.SaveChangesAsync();
        }
    }
}

