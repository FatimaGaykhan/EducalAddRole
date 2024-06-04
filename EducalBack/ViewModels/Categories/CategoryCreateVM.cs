using System;
using System.ComponentModel.DataAnnotations;

namespace EducalBack.ViewModels.Categories
{
	public class CategoryCreateVM
	{
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

