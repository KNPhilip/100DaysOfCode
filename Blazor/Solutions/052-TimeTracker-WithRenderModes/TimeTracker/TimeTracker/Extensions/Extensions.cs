using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using TimeTracker.Server.Data;
using TimeTracker.Server.Repositories;
using TimeTracker.Server.Services;
using TimeTracker.Domain.Dtos.Project;
using TimeTracker.Domain.Entities;
using Microsoft.AspNetCore.Components.Authorization;

namespace TimeTracker.Server.Extensions
{
    public static class Extensions
    {
        public static void AddServicesFromExtensionsClass(
            this IServiceCollection services, IConfiguration configuration)
        {
            AddAspNetUtils(services);

            AddIdentity(services);

            AddDbContext(services, configuration);

            AddAuth(services, configuration);

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

        private static void AddAspNetUtils(IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();
            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            services.AddRazorPages();

            services.AddHttpContextAccessor();

            services.AddControllers();
        }

        private static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        private static void AddAuth(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();

            services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme =
            //        JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme =
            //        JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = configuration["JwtIssuer"],
            //        ValidAudience = configuration["JwtAudience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            //            .GetBytes(configuration["JwtSecurityKey"]!))
            //    };
            //});
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
            services.AddScoped<AuthenticationStateProvider, ServerAuthStateProvider>();
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
