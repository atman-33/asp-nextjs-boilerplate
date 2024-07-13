using Backend.Api.Features.Todos.Dtos;
using Backend.Api.Features.Todos.Entities;

namespace Backend.Api.Features.Todos.Mapping;

public static class TodoMapping
{
  /// <summary>
  /// CreateDtoをEntityに変換する。この際、CreatedAtとUpdatedAtは現在の日時を設定する。
  /// </summary>
  /// <param name="todo"></param>
  /// <returns></returns>
  public static Todo ToEntity(this CreateTodoDto todo)
  {
    return new Todo
    {
      Name = todo.Name,
      TodoTypeId = todo.TodoTypeId,
      CreatedAt = DateTime.Now,
      UpdatedAt = DateTime.Now
    };
  }

  /// <summary>
  /// UpdateDtoをEntityに変換する。この際、UpdatedAtは現在の日時を設定する。
  /// </summary>
  /// <param name="todo"></param>
  /// <param name="id"></param>
  /// <returns></returns>
  public static Todo ToEntity(this UpdateTodoDto todo, int id, Todo exsistingTodo)
  {
    return new Todo
    {
      Id = id,
      Name = todo.Name,
      TodoTypeId = todo.TodoTypeId,
      CreatedAt = exsistingTodo.CreatedAt,
      UpdatedAt = DateTime.Now
    };
  }

  /// <summary>
  /// EntityをSummaryDtoに変換する。
  /// </summary>
  /// <param name="todo"></param>
  /// <returns></returns>
  public static TodoSummaryDto ToTodoSummaryDto(this Todo todo)
  {
    return new TodoSummaryDto(
      todo.Id,
      todo.Name,
      todo.TodoType!.Name,
      todo.CreatedAt,
      todo.UpdatedAt
    );
  }

  /// <summary>
  /// EntityをDetailDtoに変換する。
  /// </summary>
  /// <param name="todo"></param>
  /// <returns></returns>
  public static TodoDetailDto ToTodoDetailDto(this Todo todo)
  {
    return new TodoDetailDto(
      todo.Id,
      todo.Name,
      todo.TodoTypeId,
      todo.CreatedAt,
      todo.UpdatedAt
    );
  }
}
