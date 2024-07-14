using Backend.Api.Features.TodoTypes.Dtos;
using Backend.Api.Features.TodoTypes.Entities;

namespace Backend.Api.Features.TodoTypes.Mapping;

public static class TodoTypeMapping
{
  public static TodoTypeDto ToDto(this TodoType todoType)
  {
    return new TodoTypeDto(todoType.Id, todoType.Name);
  }
}
