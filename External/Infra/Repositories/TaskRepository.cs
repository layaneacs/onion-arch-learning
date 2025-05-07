using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;
public class TaskRepository(EFDbContext dbContext) : ITaskRepository
{
    public async Task<TaskItem> CreateTask(TaskItem item)
    {
        dbContext.Tasks.Add(item);
        await dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<IReadOnlyCollection<TaskItem>> GetTasks()
    {
        return await dbContext.Tasks.ToListAsync();
    }

    public async Task UpdateTask(TaskItem task)
    {
        dbContext.Update(task);
        await dbContext.SaveChangesAsync();
    }
}
