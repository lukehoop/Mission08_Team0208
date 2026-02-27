using Microsoft.EntityFrameworkCore;
using Mission08_Team0208.Models;

namespace Mission08_Team0208.Data
{
    // Bridge between the application and the database, allowing access to query and save data
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<Mission08_Team0208.Models.Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Drop down menu for categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );
            // Sample tasks to populate the database
            modelBuilder.Entity<Mission08_Team0208.Models.Task>().HasData(
                new Mission08_Team0208.Models.Task { TaskId = 1, TaskName = "Submit project", DueDate = new DateTime(2026, 3, 1), Quadrant = 1, CategoryId = 2, Completed = false },
                new Mission08_Team0208.Models.Task { TaskId = 2, TaskName = "Plan vacation", DueDate = new DateTime(2026, 3, 30), Quadrant = 2, CategoryId = 1, Completed = false },
                new Mission08_Team0208.Models.Task { TaskId = 3, TaskName = "Answer emails", DueDate = new DateTime(2026, 2, 26), Quadrant = 3, CategoryId = 3, Completed = false },
                new Mission08_Team0208.Models.Task { TaskId = 4, TaskName = "Browse social media", DueDate = null, Quadrant = 4, CategoryId = null, Completed = false }
            );
        }
    }
}