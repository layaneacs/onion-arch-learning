using Domain.Entities;
namespace Domain.Interfaces;
public interface ITaskRepository
{
    Task<TaskItem> CreateTask(TaskItem item);
    Task UpdateTask(TaskItem taskId);
    Task<IReadOnlyCollection<TaskItem>> GetTasks();
}
