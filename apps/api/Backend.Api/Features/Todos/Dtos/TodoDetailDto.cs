namespace Backend.Api.Features.Todos.Dtos;

public record class TodoDetailDto(
  int Id,
  string Name,
  int TodoTypeId,
  DateTime CreatedAt,
  DateTime UpdatedAt
);
