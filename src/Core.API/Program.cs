var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// JWT
builder.Services.AddJwt(builder.Configuration);

var app = builder.Build();

// Middlewares
app.UseCustomMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();