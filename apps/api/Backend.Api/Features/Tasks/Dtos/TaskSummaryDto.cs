namespace Backend.Api.Features.Tasks.Dtos;

public record class TaskSummaryDto(
  int Id,
  string Name,
  string TaskType,
  DateTime CreatedAt,
  DateTime UpdatedAt
);
