using Backend.Api.Data;
using Backend.Api.Features.TodoTypes.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api;

public static class TodoTypeEndpoints
{
  public static RouteGroupBuilder MapTodoTypesEndpoints(this WebApplication app)
  {

    var group = app.MapGroup("todo-types").WithParameterValidation();

    group.MapGet("/", async (BackendContext dbContext) =>
    {
      return await dbContext.TodoTypes
        .Select(todoType => todoType.ToDto())
        .AsNoTracking()
        .ToListAsync();
    });

    return group;
  }
}
