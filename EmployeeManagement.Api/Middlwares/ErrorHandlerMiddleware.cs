using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmployeeManagement.Api.Models.Wrappers;

namespace EmployeeManagement.Api.Middlwares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next) =>
        _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = MediaTypeNames.Application.Json;

        var jsonResponse = new JsonResponse<object>();

        response.StatusCode = (int)HttpStatusCode.InternalServerError;
        jsonResponse.HttpCode = HttpStatusCode.InternalServerError;
        jsonResponse.Errors = new List<string>() { exception.Message };

        var result = JsonSerializer.Serialize(jsonResponse,
            new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        await response.WriteAsync(result);
    }
}