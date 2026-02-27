namespace Mission08_Team0208.Models
{
    public interface ITaskRepository
    {
        // Defines db operations for Task entities
        IEnumerable<Task> GetAllTasks();
        Task? GetTaskById(int id);
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int id);
        void MarkCompleted(int id);
        IEnumerable<Category> GetCategories();
    }
}