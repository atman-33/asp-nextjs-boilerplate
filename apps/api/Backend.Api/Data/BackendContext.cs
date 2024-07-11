using Backend.Api.Features.TaskTypes.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Data;

public class BackendContext(DbContextOptions<BackendContext> options) : DbContext(options)
{
  public DbSet<Features.Tasks.Entities.Task> Tasks => Set<Features.Tasks.Entities.Task>();
  public DbSet<TaskType> TaskTypes => Set<TaskType>();

  /// <summary>
  /// Seed data（データの初期生成）
  /// </summary>
  /// <param name="modelBuilder"></param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<TaskType>().HasData(
      new { Id = 1, Name = "Bug", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
      new { Id = 2, Name = "Feature", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
    );
  }
}
