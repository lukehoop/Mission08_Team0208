using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0208.Models
{
    public class Task
    {
        // Primary key
        public int TaskId { get; set; }
        // Required field for the name of the task
        [Required]
        public string TaskName { get; set; } = string.Empty;

        // Optional due date for the task
        public DateTime? DueDate { get; set; }

        // Required quadrant
        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; } = false;

        // Foreign key to Category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}