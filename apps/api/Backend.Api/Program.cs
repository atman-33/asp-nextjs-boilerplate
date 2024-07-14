using Backend.Api;
using Backend.Api.Data;
using Backend.Api.Features.Todos;

var CorspolicyName = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy(CorspolicyName, policy =>
  {
    policy.WithOrigins("http://localhost:3000");
  });
});

// NOTE: EntityFrameworkCoreの設定
var connString = builder.Configuration.GetConnectionString("DataSource");
builder.Services.AddSqlite<BackendContext>(connString);

var app = builder.Build();

// NOTE: Corsの設定
app.UseCors(CorspolicyName);

// NOTE: エンドポイントを設定
app.MapTodosEndpoints();
app.MapTodoTypesEndpoints();

// NOTE: データベースのマイグレーション
await app.MigrateDbAsync();

app.Run();
