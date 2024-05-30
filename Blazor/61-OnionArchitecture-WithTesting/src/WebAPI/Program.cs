using Application;
using Concretions.Application;
using Concretions.DataAccess;
using DataAccess;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("InMem"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins("https://localhost:7032")
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.MapControllers();

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();

public sealed partial class Program { }
