using Backend.Api.Features.Todos.Entities;
using Backend.Api.Features.TodoTypes.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Data;

public class BackendContext(DbContextOptions<BackendContext> options) : DbContext(options)
{
  public DbSet<Todo> Todos => Set<Todo>();
  public DbSet<TodoType> TodoTypes => Set<TodoType>();

  /// <summary>
  /// Seed data（データの初期生成）
  /// </summary>
  /// <param name="modelBuilder"></param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<TodoType>().HasData(
      new { Id = 1, Name = "Bug", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
      new { Id = 2, Name = "Feature", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
    );
  }
}
