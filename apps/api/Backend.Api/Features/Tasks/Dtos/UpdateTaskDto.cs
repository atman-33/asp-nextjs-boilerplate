namespace Backend.Api.Features.Tasks.Dtos;

public record class UpdateTaskDto(
  string Name,
  int TaskTypeId
);
