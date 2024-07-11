using Backend.Api.Features.TaskTypes.Entities;

namespace Backend.Api.Features.Tasks.Entities;

public class Task
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public int TaskTypeId { get; set; }

  // Navigation property
  public TaskType? TaskType { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
