using System.ComponentModel.DataAnnotations;

namespace Backend.Api.Features.Todos.Dtos;

public record class CreateTodoDto(
  [Required][StringLength(50)] string Name,
  int TodoTypeId
);
