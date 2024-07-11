using System.ComponentModel.DataAnnotations;

namespace Backend.Api.Features.Tasks.Dtos;

public record class UpdateTaskDto(
  [Required][StringLength(50)] string Name,
  int TaskTypeId
);
