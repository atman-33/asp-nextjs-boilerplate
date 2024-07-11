namespace Backend.Api.Features.TaskTypes.Entities;

public class TaskType
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
