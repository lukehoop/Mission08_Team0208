using Mission08_Team0208.Data;

namespace Mission08_Team0208.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        // Communicates with the database using Entity Framework Core to add, retrieve, update, and delete Task entities
        private readonly TaskDbContext _context;

        public EFTaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAllTasks() =>
            _context.Tasks.Where(t => !t.Completed).ToList();

        public Task? GetTaskById(int id) =>
            _context.Tasks.FirstOrDefault(t => t.TaskId == id);

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public void MarkCompleted(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.Completed = true;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetCategories() =>
            _context.Categories.ToList();
    }
}