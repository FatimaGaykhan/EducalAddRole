using System;
using System.ComponentModel.DataAnnotations;

namespace EducalBack.ViewModels.Categories
{
	public class CategoryEditVM
	{
        [Required(ErrorMessage = "This input can't be empty")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This input can't be empty")]
        public string Description { get; set; }

        public string Image { get; set; }

        public IFormFile NewImage { get; set; }
    }
}

