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
    .AddScoped<MemberServices>()
    .AddScoped<CategoryServices>()
    .AddScoped<BookIssueService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

//app.UseHttpsRedirection(); 

app.UseCors(option =>
{
    option.AllowAnyHeader();
    option.AllowAnyMethod();
    option.AllowAnyOrigin();
});


var apiGroup = app.MapGroup("/api");

apiGroup
    .MapBooksEndpoints()
    .MapMemberEndpoints()
    .MapCategoryEndpoints()
    .MapBookIssuedEndpoints();


app.MapGet("/", () => $"Running in {app.Environment.EnvironmentName} right now.");


app.Run();