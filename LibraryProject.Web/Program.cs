using Microsoft.EntityFrameworkCore;
using LibraryProject.Persistence;
using LibraryProject.Services;
using LibraryProject.Web.EndPoints;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"));
});

builder.Services
    .AddScoped<BooksService>()
    .MapMemberEndpoints()
    .MapCategoryEndpoints();
   

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

var apiGroup = app.MapGroup("api");

apiGroup.MapBooksEndPoints();
   

app.MapGet("/", () => $"Running in {app.Environment.EnvironmentName} right now.");


app.Run();


