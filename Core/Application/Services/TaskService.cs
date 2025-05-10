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
        taskItem.MarkAsCompleted();
        await taskRepository.UpdateTask(taskItem);
    }

    public async Task<TaskItem> CreateTask(string title)
    {
        var taskItem = new TaskItem(Guid.NewGuid(), title);
        return await taskRepository.CreateTask(taskItem);
    }

    public async Task<IReadOnlyCollection<TaskItem>> GetTasks()
    {
        return await taskRepository.GetTasks();
    }
}
