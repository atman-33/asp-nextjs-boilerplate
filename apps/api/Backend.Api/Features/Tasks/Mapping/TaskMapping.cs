using Backend.Api.Features.Tasks.Dtos;

namespace Backend.Api.Features.Tasks.Mapping;

public static class TaskMapping
{
  public static Entities.Task ToEntity(this CreateTaskDto task)
  {
    return new Entities.Task
    {
      Name = task.Name,
      TaskTypeId = task.TaskTypeId,
      CreatedAt = DateTime.Now,
      UpdatedAt = DateTime.Now
    };
  }

  public static Entities.Task ToEntity(this UpdateTaskDto task, int id)
  {
    return new Entities.Task
    {
      Id = id,
      Name = task.Name,
      TaskTypeId = task.TaskTypeId,
      UpdatedAt = DateTime.Now
    };
  }

  public static TaskSummaryDto ToTaskSummaryDto(this Entities.Task task)
  {
    return new TaskSummaryDto(
      task.Id,
      task.Name,
      task.TaskType!.Name,
      task.CreatedAt,
      task.UpdatedAt
    );
  }

  public static TaskDetailDto ToTaskDetailDto(this Entities.Task task)
  {
    return new TaskDetailDto(
      task.Id,
      task.Name,
      task.TaskTypeId,
      task.CreatedAt,
      task.UpdatedAt
    );
  }
}
