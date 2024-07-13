namespace Backend.Api.Features.Todos.Dtos;

public record class TodoSummaryDto(
  int Id,
  string Name,
  string TodoType,
  DateTime CreatedAt,
  DateTime UpdatedAt
);
