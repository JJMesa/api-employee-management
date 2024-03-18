using EmployeeManagement.Api.Commons;
using EmployeeManagement.Api.interfaces;
using EmployeeManagement.Api.Models.Dtos;
using EmployeeManagement.Api.Models.Entities;
using EmployeeManagement.Api.Models.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Ruotes;

public static class EmployeesRoutes
{
    public static void MapEmployeeRoutes(this WebApplication app)
    {
        const string API_EMPLOYEE_PATH = $"{Routes.API_ROUTE}{Routes.API_VERSION}{Routes.EMPLOYEE_ROUTE}";

        //GET: /api/v1/employees
        app.MapGet(API_EMPLOYEE_PATH, async ([FromServices] IEmployeeService service) =>
        {
            var response = await service.GetEmployeesAsync();
            return Results.Json(data: response, statusCode: (int)response.HttpCode);
        })
        .Produces<JsonResponse<List<EmployeeDto>>>(200);

        //GET: /api/v1/employees/1
        app.MapGet($"{API_EMPLOYEE_PATH}/{{id:int}}", async ([FromServices] IEmployeeService service, int id) =>
        {
            var response = await service.GetEmployeeByIdAsync(id);
            return Results.Json(data: response, statusCode: (int)response.HttpCode);
        })
        .Produces<JsonResponse<EmployeeDto>>(200);

        //POST: /api/v1/employees
        app.MapPost(API_EMPLOYEE_PATH, async ([FromServices] IEmployeeService service
            , [FromBody] EmployeeCreationDto employeeCreationDto) =>
        {
            var response = await service.CreateEmployeeAsync(employeeCreationDto);
            return Results.Json(data: response, statusCode: (int)response.HttpCode);
        })
        .Produces<JsonResponse<EmployeeDto>>(201);

        //PUT: /api/v1/employees/1
        app.MapPut($"{API_EMPLOYEE_PATH}/{{id:int}}", async ([FromServices] IEmployeeService service
            , int id
            , [FromBody] EmployeeUpdateDto employeeUpdateDto) =>
        {
            var response = await service.UpdateEmployeeAsync(id, employeeUpdateDto);
            return Results.Json(data: response, statusCode: (int)response.HttpCode);
        })
        .Produces<JsonResponse<EmployeeDto>>(200);

        //POST: /api/v1/employees/1
        app.MapDelete($"{API_EMPLOYEE_PATH}/{{id:int}}", async ([FromServices] IEmployeeService service, int id) =>
        {
            var response = await service.DeleteEmployeeAsync(id);
            return Results.Json(data: response, statusCode: (int)response.HttpCode);
        })
        .Produces<JsonResponse<bool>?>(204);
    }
}