using Core.Application;
using Core.Infrastructure;

using Serilog;
using Serilog.Events;
using Core.Infrastructure.Security;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate: "{Timestamp:HH:mm} [{Level}] ({SourceContext}) {Message}{NewLine}{Exception}")
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();

// Logger
builder.Host.UseSerilog();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

// JWT
builder.Services.Configure<JwtSettings>(
builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

// Middlewares
app.UseCustomMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();