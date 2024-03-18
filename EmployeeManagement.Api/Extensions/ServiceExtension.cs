using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;
using EmployeeManagement.Api.Context;
using EmployeeManagement.Api.interfaces;
using EmployeeManagement.Api.Models.Wrappers;
using EmployeeManagement.Api.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Extensions;

public static class ServiceExtension
{
    public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
    }

    public static void AddApplicationSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "EmployeeManagement.Api", Version = "v1" });
        });
    }

    public static void AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    public static void AddFluentValidationConfig(this IServiceCollection services)
    {
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es-CO");
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.Configure<ApiBehaviorOptions>(opt => opt.InvalidModelStateResponseFactory = actionContext =>
        {
            var jsonResponse = new JsonResponse<object>
            {
                HttpCode = HttpStatusCode.BadRequest,
                Errors = actionContext.ModelState.Values
                .Where(v => v.Errors.Count > 0)
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
            };

            return new BadRequestObjectResult(jsonResponse);
        });
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IFileStorageService, FileStorageService>();
        services.AddTransient<IEmployeeService, EmployeeService>();
    }

    public static void AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Security",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    public static void AddResponseConfig(this IServiceCollection services)
    {
        services.Configure<JsonOptions>(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
    }
}