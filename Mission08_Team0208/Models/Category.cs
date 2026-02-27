namespace Mission08_Team0208.Models
{
    public class Category
    {
        // Represents category table in the db
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}