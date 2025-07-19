using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ApiKey.Generate();
var pythonProcess = new PythonLogger();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConStr"));
    options.UseLowerCaseNamingConvention();
    });

var app = builder.Build();
app.UseHttpsRedirection();

app.MapControllers();

app.Run("http://localhost:5001");
