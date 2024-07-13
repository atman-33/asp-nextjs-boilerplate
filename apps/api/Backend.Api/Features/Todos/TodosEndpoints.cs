using Backend.Api.Data;
using Backend.Api.Features.Todos.Dtos;
using Backend.Api.Features.Todos.Entities;
using Backend.Api.Features.Todos.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Features.Todos;

public static class TodosEndpoints
{
  const string GetTodoEndpointName = "GetTodo";

  public static RouteGroupBuilder MapTodosEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("todos").WithParameterValidation();

    // GET /todos
    group.MapGet("/", async (BackendContext dbContext) =>
    {
      return await dbContext.Todos
        .Include(todo => todo.TodoType) // NOTE: TodoTypeのナビゲーションプロパティを取得するために必要
        .Select(todo => todo.ToTodoSummaryDto())
        .AsNoTracking()  // NOTE: EF Core によるデータの変更追跡を無視する（パフォーマンス向上のため）
        .ToListAsync();
    });

    // GET /todos/{id}
    group.MapGet("/{id}", async (int id, BackendContext dbContext) =>
    {
      Todo? todo = await dbContext.Todos.FindAsync(id);
      return todo is null ? Results.NotFound() : Results.Ok(todo.ToTodoDetailDto());
    })
    .WithName(GetTodoEndpointName);

    // POST /todos
    group.MapPost("/", async (CreateTodoDto newTodo, BackendContext dbContext) =>
    {
      Todo todo = newTodo.ToEntity();

      dbContext.Todos.Add(todo);
      await dbContext.SaveChangesAsync();

      return Results.CreatedAtRoute(GetTodoEndpointName, new { id = todo.Id }, todo.ToTodoDetailDto());
    });

    // PUT /todos/{id}
    group.MapPut("/{id}", async (int id, UpdateTodoDto updatedTodo, BackendContext dbContext) =>
    {
      Todo? existingTodo = await dbContext.Todos.FindAsync(id);

      if (existingTodo is null)
      {
        return Results.NotFound();
      }

      dbContext.Entry(existingTodo).CurrentValues.SetValues(updatedTodo.ToEntity(id, existingTodo));
      await dbContext.SaveChangesAsync();

      // NOTE: PUTメソッドの戻り値は204 No Content
      return Results.NoContent();
    });

    // DELETE /todos/{id}
    group.MapDelete("/{id}", async (int id, BackendContext dbContext) =>
    {
      await dbContext.Todos.Where(todo => todo.Id == id).ExecuteDeleteAsync();

      return Results.NoContent();
    });

    return group;
  }
}
