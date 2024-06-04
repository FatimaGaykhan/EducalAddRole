using System;
using System.Reflection.Metadata;
using EducalBack.Data;
using EducalBack.Models;
using EducalBack.Services.Interfaces;
using EducalBack.ViewModels;
using EducalBack.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EducalBack.Services
{
	public class CategoryService:ICategoryService
	{
		private readonly AppDbContext _context;

		public CategoryService(AppDbContext context)
		{
			_context = context;
		}

        public async Task CreateAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> DetailAsync(int id)
        {
            return await _context.Categories.Where(m => m.Id == id)
                                            .Include(m => m.Courses)
                                            .ThenInclude(m => m.CourseImages)
                                            .FirstOrDefaultAsync();
                                       
        }

        public async Task EditAsync(Category category, CategoryEditVM request)
        {
            category.Name = request.Name;
            category.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task<bool> ExistExceptByIdAsync(int id, string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name == name && m.Id != id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
			return await _context.Categories.ToListAsync();
        }

       

        public async Task<SelectList> GetAllSelectedAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }

        public async Task<IEnumerable<CategoryCourseVM>> GetAllWithCourseCountAysnc()
        {
            IEnumerable<Category> categories = await _context.Categories.Include(m => m.Courses)
                                                                        .OrderByDescending(m => m.Id)
                                                                        .ToListAsync();

            return categories.Select(m => new CategoryCourseVM
            {
                Id = m.Id,
                Name = m.Name,
                Icon = m.Image,
                CourseCount = m.Courses.Count,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy"),
                Description = m.Description
            });
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}

