using Backend.Api.Data;
using Backend.Api.Features.Tasks.Dtos;
using Backend.Api.Features.Tasks.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Features.Tasks;

public static class TasksEndpoints
{
  const string GetTaskEndpointName = "GetTask";

  private static readonly List<TaskSummaryDto> tasks = [
    new TaskSummaryDto(1, "Task 1", "Type A", new DateTime(2022, 1, 1), new DateTime(2022, 1, 2)),
    new TaskSummaryDto(2, "Task 2", "Type B", new DateTime(2022, 1, 1), new DateTime(2022, 1, 2)),
    new TaskSummaryDto(3, "Task 3", "Type C", new DateTime(2022, 1, 1), new DateTime(2022, 1, 2))
  ];

  public static RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("tasks").WithParameterValidation();

    // GET /tasks
    group.MapGet("/", async (BackendContext dbContext) =>
    {
      await dbContext.Tasks
        .Include(task => task.TaskType) // NOTE: ナビゲーションプロパティを取得
        .Select(task => task.ToTaskSummaryDto())
        .AsNoTracking()
        .ToListAsync();
    });

    // TODO: ここから変更が必要!!

    // GET /tasks/{id}
    group.MapGet("/{id}", (int id) =>
    {
      TaskSummaryDto? task = tasks.Find(task => task.Id == id);

      return task is null ? Results.NotFound() : Results.Ok(task);
    })
    .WithName(GetTaskEndpointName);

    // POST /tasks
    group.MapPost("/", (CreateTaskDto newTask) =>
    {
      TaskSummaryDto task = new(
        tasks.Count + 1,
        newTask.Name,
        newTask.TaskTypeId.ToString(),
        DateTime.Now,
        DateTime.Now
      );
      tasks.Add(task);

      return Results.CreatedAtRoute(GetTaskEndpointName, new { id = task.Id }, task);
    });

    // PUT /tasks/{id}
    group.MapPut("/{id}", (int id, UpdateTaskDto updateTask) =>
    {
      var index = tasks.FindIndex(task => task.Id == id);

      if (index == -1)
      {
        return Results.NotFound();
      }

      tasks[index] = new TaskSummaryDto(
        id,
        updateTask.Name,
        updateTask.TaskTypeId.ToString(),
        tasks[index].CreatedAt,
        DateTime.Now
      );

      return Results.NoContent();
    });

    // DELETE /tasks/{id}
    group.MapDelete("/{id}", (int id) =>
    {
      tasks.RemoveAll(task => task.Id == id);

      return Results.NoContent();
    });

    return group;
  }
}
