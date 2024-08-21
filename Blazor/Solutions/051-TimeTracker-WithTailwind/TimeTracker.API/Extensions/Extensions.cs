using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using TimeTracker.API.Data;
using TimeTracker.API.Repositories;
using TimeTracker.API.Services;
using TimeTracker.Domain.Dtos.Project;
using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Extensions
{
    public static class Extensions
    {
        public static void AddServicesFromExtensionsClass(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                //options.UseInMemoryDatabase("TimeTrackerDb");
            });

            services.AddHttpContextAccessor();

            AddIdentity(services);

            AddAuthentication(services, configuration);

            AddRepositories(services);

            AddServices(services);

            AddSwagger(services);
        }

        public static void ConfigureMapster()
        {
            TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;

            config.ForType<Project, ProjectResponseDto>()
                .Map(dest => dest.Description,
                    src => src.ProjectDetails == null ? null : src.ProjectDetails.Description)
                .Map(dest => dest.StartDate,
                    src => src.ProjectDetails == null ? null : src.ProjectDetails.StartDate)
                .Map(dest => dest.EndDate,
                    src => src.ProjectDetails == null ? null : src.ProjectDetails.EndDate);
        }

        private static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtIssuer"],
                    ValidAudience = configuration["JwtAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(configuration["JwtSecurityKey"]!))
                };
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ITimeEntryService, TimeEntryService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization"
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
    }
}
