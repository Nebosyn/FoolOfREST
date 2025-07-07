using FoolOfRESTAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConStr"));
    options.UseLowerCaseNamingConvention();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("messages/{id}", async (int id, [FromServices] AppDbContext db) =>
{
	try
	{
        var msg = await db.Messages.FirstAsync(x => x.Id == id);
        MessageResponseModel response = new(msg); 
        return Results.Ok(response);
    }
	catch (InvalidOperationException e)
	{
        if (e.Message== "Sequence contains no elements.")
        {
            return Results.NotFound();
        }
        throw;
	}
});

app.MapGet("messages", ([FromServices] AppDbContext db) =>
{
    List<MessageResponseModel> response = new();
    response.AddRange(db.Messages.Select(msg => new MessageResponseModel(msg)));
    return Results.Ok(response);
});

app.MapGet("users/{id}", async (int id, [FromServices] AppDbContext db) =>
{
	try
	{
        var res = await db.Users.FirstAsync(x => x.Id == id);
        return Results.Ok(res);
    }
	catch (InvalidOperationException e)
	{
        if (e.Message== "Sequence contains no elements.")
        {
            return Results.NotFound();
        }
        throw;
	}
});

app.MapGet("Chats/{id}", async (string id, [FromServices] AppDbContext db) =>
{
	try
	{
        var res = await db.Chats.FirstAsync(x => x.Id == id);
        return Results.Ok(res);
    }
	catch (InvalidOperationException e)
	{
        if (e.Message== "Sequence contains no elements.")
        {
            return Results.NotFound();
        }
        throw;
	}
});

app.Run();

