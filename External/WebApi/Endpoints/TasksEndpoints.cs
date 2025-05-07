using Application.Services;
using Domain.Entities;
using Domain.Interfaces;

namespace WebApi.Endpoints;
public static class TasksEndpoints
{
    public static void MapTasksEndpoints(this WebApplication app)
    {
        app.MapGet("/tasks", async (TaskService service) =>
        {
            var tasks = await service.GetTasks();
            return Results.Ok(tasks);
        });

        app.MapPost("/tasks", async (TaskService service, CreateTaskRequest task) =>
        {
            var createdTask = await service.CreateTask(task.Title);
            return Results.Created($"/tasks/{createdTask.Id}", createdTask);
        });

        app.MapPut("/tasks/{id}/complete",
        async (
            TaskService service,
            Guid id,
            TaskItem taskItem) =>
        {
            if (id != taskItem.Id)
            {
                return Results.BadRequest("Task ID mismatch.");
            }

            await service.CompleteTask(taskItem);
            return Results.NoContent();
        });
    }
}
