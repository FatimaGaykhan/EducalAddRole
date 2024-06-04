using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducalBack.Migrations
{
    public partial class CourseCategoryCourseImagetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseImages_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "Image", "Name", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7730), "Development is everything", "category-icon-1.jpeg", "Development", false },
                    { 2, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7740), "Design is everything", "category-icon-2.jpeg", "Design", false },
                    { 3, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7740), "Data is everything", "category-icon-3.jpeg", "Data Science", false },
                    { 4, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7740), "Improve your business", "category-icon-4.jpeg", "Business", false },
                    { 5, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7740), "Fun and Challenging", "category-icon-5.jpeg", "Finance", false },
                    { 6, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7750), "Invest to your body", "category-icon-6.jpeg", "Health and Fitness", false },
                    { 7, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7750), "Improve your business", "category-icon-7.jpeg", "Marketing", false },
                    { 8, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7750), "New Skills,New You", "category-icon-8.jpeg", "Lifestyle", false },
                    { 9, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7750), "Major or Minor", "category-icon-9.jpeg", "Music", false }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Name", "Price", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7810), "Front-End is everything", "Front-End", 2500m, false },
                    { 2, 1, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7810), "Back-End is everything", "Back-End", 4000m, false },
                    { 3, 2, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7820), "UX-UI is everything", "UX-UI", 2525m, false },
                    { 4, 2, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7820), "Design is everything", "Graphic Design", 1600m, false },
                    { 5, 3, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7820), "Data is everything", "Data Analytics", 4500m, false },
                    { 6, 8, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7820), "Pilates is everything", "Pilates", 1300m, false },
                    { 7, 7, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7830), "SMM is everything", "SMM", 1200m, false },
                    { 8, 9, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7830), "Piano is everything", "Piano Lessons", 340m, false },
                    { 9, 9, new DateTime(2024, 6, 1, 14, 23, 16, 773, DateTimeKind.Local).AddTicks(7830), "Guitar is everything", "Guitar Lessons", 300m, false }
                });

            migrationBuilder.InsertData(
                table: "CourseImages",
                columns: new[] { "Id", "CourseId", "IsMain", "Name" },
                values: new object[,]
                {
                    { 1, 1, true, "course-1.jpeg" },
                    { 2, 1, false, "course-2.jpeg" },
                    { 3, 2, false, "course-3.jpeg" },
                    { 4, 2, true, "course-4.jpeg" },
                    { 5, 3, false, "course-5.jpeg" },
                    { 6, 3, true, "course-6.jpeg" },
                    { 7, 4, true, "course-1.jpeg" },
                    { 8, 4, false, "course-2.jpeg" },
                    { 9, 5, false, "course-3.jpeg" },
                    { 10, 5, true, "course-4.jpeg" },
                    { 11, 6, true, "course-5.jpeg" },
                    { 12, 6, false, "course-6.jpeg" },
                    { 13, 7, true, "course-1.jpeg" },
                    { 14, 7, false, "course-2.jpeg" },
                    { 15, 8, false, "course-3.jpeg" },
                    { 16, 8, true, "course-4.jpeg" },
                    { 17, 9, true, "course-5.jpeg" },
                    { 18, 9, false, "course-6.jpeg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseImages_CourseId",
                table: "CourseImages",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseImages");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
