using Backend.Api.Features.TodoTypes.Entities;

namespace Backend.Api.Features.Todos.Entities;

public class Todo
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public int TodoTypeId { get; set; }

  // NOTE: Navigation property
  public TodoType? TodoType { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
