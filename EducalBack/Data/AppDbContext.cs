using System;
using System.Reflection.Metadata;
using EducalBack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducalBack.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id=1,
                    Name="Development",
                    Description="Development is everything",
                    Image= "category-icon-1.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Category
                {
                    Id = 2,
                    Name = "Design",
                    Description = "Design is everything",
                    Image = "category-icon-2.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Category
                {
                    Id = 3,
                    Name = "Data Science",
                    Description = "Data is everything",
                    Image = "category-icon-3.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Category
                {
                    Id = 4,
                    Name = "Business",
                    Description = "Improve your business",
                    Image = "category-icon-4.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Category
                {
                    Id = 5,
                    Name = "Finance",
                    Description = "Fun and Challenging",
                    Image = "category-icon-5.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Category
                {
                    Id = 6,
                    Name = "Health and Fitness",
                    Description = "Invest to your body",
                    Image = "category-icon-6.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Category
                {
                    Id = 7,
                    Name = "Marketing",
                    Description = "Improve your business",
                    Image = "category-icon-7.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Category
                {
                    Id = 8,
                    Name = "Lifestyle",
                    Description = "New Skills,New You",
                    Image = "category-icon-8.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Category
                {
                    Id = 9,
                    Name = "Music",
                    Description = "Major or Minor",
                    Image = "category-icon-9.jpeg",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                }
        
                );




            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "Front-End",
                    Description = "Front-End is everything",
                    Price = 2500,
                    CategoryId=1,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 2,
                    Name = "Back-End",
                    Description = "Back-End is everything",
                    Price = 4000,
                    CategoryId = 1,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 3,
                    Name = "UX-UI",
                    Description = "UX-UI is everything",
                    Price = 2525,
                    CategoryId = 2,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 4,
                    Name = "Graphic Design",
                    Description = "Design is everything",
                    Price = 1600,
                    CategoryId = 2,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 5,
                    Name = "Data Analytics",
                    Description = "Data is everything",
                    Price = 4500,
                    CategoryId = 3,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 6,
                    Name = "Pilates",
                    Description = "Pilates is everything",
                    Price = 1300,
                    CategoryId = 8,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 7,
                    Name = "SMM",
                    Description = "SMM is everything",
                    Price = 1200,
                    CategoryId = 7,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 8,
                    Name = "Piano Lessons",
                    Description = "Piano is everything",
                    Price = 340,
                    CategoryId = 9,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 9,
                    Name = "Guitar Lessons",
                    Description = "Guitar is everything",
                    Price = 300,
                    CategoryId = 9,
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                }

                );





            modelBuilder.Entity<CourseImage>().HasData(
                new CourseImage
                {
                    Id = 1,
                    Name = "course-1.jpeg",
                    IsMain=true,
                    CourseId = 1,
                    
                },
                new CourseImage
                {
                    Id = 2,
                    Name = "course-2.jpeg",
                    IsMain = false,
                    CourseId = 1,

                },
                new CourseImage
                {
                    Id = 3,
                    Name = "course-3.jpeg",
                    IsMain = false,
                    CourseId = 2,

                },
                new CourseImage
                {
                    Id = 4,
                    Name = "course-4.jpeg",
                    IsMain = true,
                    CourseId = 2,

                },
                new CourseImage
                {
                    Id = 5,
                    Name = "course-5.jpeg",
                    IsMain = false,
                    CourseId = 3,

                },
                new CourseImage
                {
                    Id = 6,
                    Name = "course-6.jpeg",
                    IsMain = true,
                    CourseId = 3,

                },
                new CourseImage
                {
                    Id = 7,
                    Name = "course-1.jpeg",
                    IsMain = true,
                    CourseId = 4,

                },
                new CourseImage
                {
                    Id = 8,
                    Name = "course-2.jpeg",
                    IsMain = false,
                    CourseId = 4,

                },
                new CourseImage
                {
                    Id = 9,
                    Name = "course-3.jpeg",
                    IsMain = false,
                    CourseId = 5,

                },
                new CourseImage
                {
                    Id = 10,
                    Name = "course-4.jpeg",
                    IsMain = true,
                    CourseId = 5,

                },
                new CourseImage
                {
                    Id = 11,
                    Name = "course-5.jpeg",
                    IsMain = true,
                    CourseId = 6,

                },
                new CourseImage
                {
                    Id = 12,
                    Name = "course-6.jpeg",
                    IsMain = false,
                    CourseId = 6,

                },
                new CourseImage
                {
                    Id = 13,
                    Name = "course-1.jpeg",
                    IsMain = true,
                    CourseId = 7,

                },
                new CourseImage
                {
                    Id = 14,
                    Name = "course-2.jpeg",
                    IsMain = false,
                    CourseId = 7,

                },
                new CourseImage
                {
                    Id = 15,
                    Name = "course-3.jpeg",
                    IsMain = false,
                    CourseId = 8,

                },
                new CourseImage
                {
                    Id = 16,
                    Name = "course-4.jpeg",
                    IsMain = true,
                    CourseId = 8,

                },
                new CourseImage
                {
                    Id = 17,
                    Name = "course-5.jpeg",
                    IsMain = true,
                    CourseId = 9,

                },
                new CourseImage
                {
                    Id = 18,
                    Name = "course-6.jpeg",
                    IsMain = false,
                    CourseId = 9,

                }


                );

            base.OnModelCreating(modelBuilder);




        }

    }
}

