using System.Diagnostics;
using EducalBack.Models;
using EducalBack.Services.Interfaces;
using EducalBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace EducalBack.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ICourseService _courseService;
    private readonly UserManager<AppUser> _userManager;

    public HomeController(ICategoryService categoryService,
                         ICourseService courseService,
                         UserManager<AppUser> userManager)
    {
        _categoryService = categoryService;
        _courseService = courseService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        AppUser user = new();
        if (User.Identity.IsAuthenticated)
        {
            user = await _userManager.FindByNameAsync(User.Identity.Name);

        }

        HomeVM model = new()
        {
            Categories = await _categoryService.GetAllAsync(),
            Courses = await _courseService.GetAllAsync(),
            UserFullName=user.FullName
        };
    
        return View(model);
    }

    //public async Task<IActionResult> GetByIdForCategoryTabMenu(int? id)
    //{
    //    //IEnumerable<Course> courses = await _courseService.GetAllAsync();

    //    if (id is null) return BadRequest();

    //    List<Course> courses = await _courseService.GetAllCoursesById((int)id);

    //    if (courses.Count == 0) return NotFound();

    //    return Ok(courses);
    //}

   
}

