namespace Backend.Api.Features.Tasks.Dtos;

public record class CreateTaskDto(
  string Name,
  int TaskTypeId
);
