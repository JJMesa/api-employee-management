using EmployeeManagement.Api.Middlwares;
using EmployeeManagement.Api.Ruotes;

namespace EmployeeManagement.Api.Extensions;

public static class AppExtension
{
    public static void AddRoutes(this WebApplication app)
    {
        app.MapEmployeeRoutes();
    }

    public static void AddErrorHandler(this WebApplication app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}