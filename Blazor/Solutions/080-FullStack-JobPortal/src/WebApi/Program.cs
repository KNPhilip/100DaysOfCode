using DataAccess;
using DataAccess.Data;
using Interactors.Company;
using Interactors.JobPost;
using Interactors.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using WebApi.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Entity Framework
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<JobPostRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<CompanyRepository>();

// Interactors
builder.Services.AddScoped<JobPostInteractor>();
builder.Services.AddScoped<UserInteractor>();
builder.Services.AddScoped<CompanyInteractor>();

// Services
builder.Services.AddScoped<AuthService>();

// ASP.NET
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Standard authorization header using the bearer scheme: (\"bearer {Token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration["EncryptionKey"]
                    ?? throw new Exception("Encryption key not set.."))),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
