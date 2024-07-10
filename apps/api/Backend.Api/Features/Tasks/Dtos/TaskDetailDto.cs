namespace Backend.Api.Features.Tasks.Dtos;

public record class TaskDetailDto(
  int Id,
  string Name,
  int TaskTypeId,
  DateTime CreatedAt,
  DateTime UpdatedAt
);
