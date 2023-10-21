using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using RetroBack.Application.Queries.AccountQueries;
using RetroBack.Application.Bootstrap;
using RetroBack.Common.Config;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Infrastructure.Bootstrap;
using RetroBack.Persistence;
using RetroBack.Persistence.Bootstrap;
using RetroBack.Web.Bootstrap;
using RetroBack.Web.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RetroFootballDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

IConfigurationSection jwtSettings = builder.Configuration.GetSection("jwtConfig");
string jwtSecret = jwtSettings["secret"];

JwtConfig jwtConfig = new()
{
    Audience = jwtSettings["validAudience"],
    ExpiresIn = Convert.ToDouble(jwtSettings["expiresIn"]),
    Issuer = jwtSettings["validIssuer"],
    Secret = jwtSettings["secret"]
};

builder.Services
    .AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["validIssuer"],
            ValidAudience = jwtSettings["validAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
    });

builder.Services.AddIdentity<ApplicationUser, Role>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequiredLength = 6;
    o.Password.RequireUppercase = false;
    o.Password.RequireLowercase = false;
    o.User.RequireUniqueEmail = true;
    o.SignIn.RequireConfirmedEmail = false;
})
                 .AddEntityFrameworkStores<RetroFootballDbContext>()
                 .AddDefaultTokenProviders();

builder.Services.AddScoped<CustomExceptionFilterAttribute>();
builder.Services.AddControllersWithViews(options => options.Filters.Add<CustomExceptionFilterAttribute>())
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddControllers(options => options.Filters.Add<CustomExceptionFilterAttribute>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetLoggedInUserQuery).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(GetLoggedInUserQuery).Assembly);

builder.Services.RegisterInfrastructureComponents();
builder.Services.RegisterApplicationServices();
builder.Services.RegisterRepositories();
builder.Services.RegisterWebAPIServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`. You need to execute one of the Login methods to get the token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
});

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped(x =>
{
    ActionContext? actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    IUrlHelperFactory factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});

builder.Services.AddSingleton(jwtConfig);

WebApplication app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using (var context = scope.ServiceProvider.GetRequiredService<RetroFootballDbContext>())
    {
        context.Database.Migrate();
        if (!context.Roles.Any())
        {
            context.Roles.Add(new Role { Id = Guid.NewGuid().ToString(), Name = Roles.Admin, NormalizedName = Roles.Admin.ToUpper() });
            context.Roles.Add(new Role { Id = Guid.NewGuid().ToString(), Name = Roles.User, NormalizedName = Roles.User.ToUpper() });
            context.Roles.Add(new Role { Id = Guid.NewGuid().ToString(), Name = Roles.Manager, NormalizedName = Roles.Manager.ToUpper() });
            context.SaveChanges();
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
