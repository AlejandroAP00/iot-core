using Core.Application.Interfaces;
using Core.Application.Services;
using Core.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

// JWT
builder.Services.AddJwt(builder.Configuration);

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