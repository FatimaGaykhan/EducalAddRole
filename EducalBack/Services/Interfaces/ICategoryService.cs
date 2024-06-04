using System;
using System.Reflection.Metadata;
using EducalBack.Models;
using EducalBack.ViewModels;
using EducalBack.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducalBack.Services.Interfaces
{
	public interface ICategoryService
	{
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<CategoryCourseVM>> GetAllWithCourseCountAysnc();
        Task<Category> DetailAsync(int id);
        Task<bool> ExistAsync(string name);
        Task CreateAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task DeleteAsync(Category category);
        Task<SelectList> GetAllSelectedAsync();
        Task<bool> ExistExceptByIdAsync(int id, string name);
        Task EditAsync(Category category, CategoryEditVM request);

    }
}

