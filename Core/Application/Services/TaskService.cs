using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
public class TaskService(ITaskRepository taskRepository)
{
    public async Task CompleteTask(TaskItem taskItem)
    {
        if (taskItem == null)
        {
            throw new ArgumentNullException(nameof(taskItem));
        }
        taskItem.IsCompleted = true;
        await taskRepository.UpdateTask(taskItem);
    }

    public async Task<TaskItem> CreateTask(string title)
    {
        var taskItem = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = title,
            IsCompleted = false
        };
        return await taskRepository.CreateTask(taskItem);
    }

    public async Task<IReadOnlyCollection<TaskItem>> GetTasks()
    {
        return await taskRepository.GetTasks();
    }
}
