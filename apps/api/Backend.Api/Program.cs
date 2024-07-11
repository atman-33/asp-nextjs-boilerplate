using Backend.Api.Data;
using Backend.Api.Features.Tasks;

var builder = WebApplication.CreateBuilder(args);

// NOTE: EntityFrameworkCoreの設定
var connString = builder.Configuration.GetConnectionString("DataSource");
builder.Services.AddSqlite<BackendContext>(connString);

var app = builder.Build();

// NOTE: エンドポイントを設定
app.MapTasksEndpoints();

app.Run();
