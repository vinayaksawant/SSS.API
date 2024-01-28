using SSS.API.Data;
using Microsoft.EntityFrameworkCore;
using SSS.API.Repositories.Interface;
using SSS.API.Repositories.Implementaion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>( options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SSSConnectionstring"));
    });

builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<IJobPostingRepository, JobPostingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(option =>
{
    option.AllowAnyHeader();
    option.AllowAnyOrigin();
    option.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
