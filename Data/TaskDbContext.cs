using Microsoft.EntityFrameworkCore;
using Mission08_Team0208.Models;

namespace Mission08_Team0208.Data
{
	public class TaskDbContext : DbContext
	{
		public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

		public DbSet<Models.Task> Tasks { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Seed Categories
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = 1, CategoryName = "Home" },
				new Category { CategoryId = 2, CategoryName = "School" },
				new Category { CategoryId = 3, CategoryName = "Work" },
				new Category { CategoryId = 4, CategoryName = "Church" }
			);

			// Seed some sample Tasks
			modelBuilder.Entity<Models.Task>().HasData(
				new Models.Task
				{
					TaskId = 1,
					TaskName = "Submit project",
					DueDate = DateTime.Now.AddDays(2),
					Quadrant = 1,
					CategoryId = 2,
					Completed = false
				},
				new Models.Task
				{
					TaskId = 2,
					TaskName = "Plan vacation",
					DueDate = DateTime.Now.AddDays(30),
					Quadrant = 2,
					CategoryId = 1,
					Completed = false
				},
				new Models.Task
				{
					TaskId = 3,
					TaskName = "Answer emails",
					DueDate = DateTime.Now.AddDays(1),
					Quadrant = 3,
					CategoryId = 3,
					Completed = false
				},
				new Models.Task
				{
					TaskId = 4,
					TaskName = "Browse social media",
					DueDate = null,
					Quadrant = 4,
					CategoryId = null,
					Completed = false
				}
			);
		}
	}
}