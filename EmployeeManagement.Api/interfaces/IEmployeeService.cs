using EmployeeManagement.Api.Models.Dtos;
using EmployeeManagement.Api.Models.Entities;
using EmployeeManagement.Api.Models.Wrappers;

namespace EmployeeManagement.Api.interfaces;

public interface IEmployeeService
{
    Task<JsonResponse<IEnumerable<EmployeeDto>>> GetEmployeesAsync();

    Task<JsonResponse<EmployeeDto>> GetEmployeeByIdAsync(int id);

    Task<JsonResponse<EmployeeDto>> CreateEmployeeAsync(EmployeeCreationDto employeeCreationDto);

    Task<JsonResponse<EmployeeDto>> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdateDto);

    Task<JsonResponse<bool?>> DeleteEmployeeAsync(int id);
}