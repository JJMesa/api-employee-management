using AutoMapper;
using EmployeeManagement.Api.Builders;
using EmployeeManagement.Api.Commons;
using EmployeeManagement.Api.Context;
using EmployeeManagement.Api.interfaces;
using EmployeeManagement.Api.Models.Dtos;
using EmployeeManagement.Api.Models.Entities;
using EmployeeManagement.Api.Models.Wrappers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Services;

internal class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IFileStorageService _fileStorageService;
    private readonly IValidator<EmployeeCreationDto> _creationValidator;
    private readonly IValidator<EmployeeUpdateDto> _updateValidator;

    public EmployeeService(ApplicationDbContext context
        , IMapper mapper
        , IFileStorageService fileStorageService
        , IValidator<EmployeeCreationDto> creationValidator
        , IValidator<EmployeeUpdateDto> updateValidator)
    {
        _context = context;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
        _creationValidator = creationValidator;
        _updateValidator = updateValidator;
    }

    public async Task<JsonResponse<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
    {
        var employees = await _context.Employees!.ToListAsync();
        return JsonResponseBuilder<IEnumerable<EmployeeDto>>.Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
    }

    public async Task<JsonResponse<EmployeeDto>> GetEmployeeByIdAsync(int id)
    {
        var employee = await _context.Employees!.FirstOrDefaultAsync(e => e.EmployeeId == id);
        if (employee is null)
            return JsonResponseBuilder<EmployeeDto>.NotFound();

        return JsonResponseBuilder<EmployeeDto>.Ok(_mapper.Map<EmployeeDto>(employee));
    }

    public async Task<JsonResponse<EmployeeDto>> CreateEmployeeAsync(EmployeeCreationDto employeeCreationDto)
    {
        ValidateDataEmployeeAsync(employeeCreationDto, true);

        string identification = employeeCreationDto.Identification;

        if (await IsDuplicateIdentificationAsync(identification))
            return JsonResponseBuilder<EmployeeDto>.BadRequest(ErrorMessages.IdentificationAlreadyExists);

        var employee = _mapper.Map<Employee>(employeeCreationDto);

        string contentBase64 = employeeCreationDto.ContentBase64;
        string extension = employeeCreationDto.Extension;
        employee.PathPhoto = await SavePhotoAsync(contentBase64, identification, extension);

        _context.Employees!.Add(employee);
        await _context.SaveChangesAsync();

        return JsonResponseBuilder<EmployeeDto>.Created(_mapper.Map<EmployeeDto>(employee));
    }

    public async Task<JsonResponse<EmployeeDto>> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeUpdateDto)
    {
        ValidateDataEmployeeAsync(employeeUpdateDto, false);

        if (id != employeeUpdateDto.EmployeeId)
            return JsonResponseBuilder<EmployeeDto>.BadRequest(ErrorMessages.UrlAndBodyIdNotEqual);

        var employee = await _context.Employees!.FirstOrDefaultAsync(e => e.EmployeeId == id);
        if (employee is null) return JsonResponseBuilder<EmployeeDto>.NotFound();

        _mapper.Map(employeeUpdateDto, employee);

        if (employeeUpdateDto.ImageChange)
        {
            string contentBase64 = employeeUpdateDto.ContentBase64;
            string extension = employeeUpdateDto.Extension;
            employee.PathPhoto = await SavePhotoAsync(contentBase64, employee.Identification, extension);
        }

        _context.Employees!.Update(employee);
        await _context.SaveChangesAsync();

        return JsonResponseBuilder<EmployeeDto>.Ok(_mapper.Map<EmployeeDto>(employee));
    }

    public async Task<JsonResponse<bool?>> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees!.FindAsync(id);
        if (employee is null) return JsonResponseBuilder<bool?>.NotFound();

        _fileStorageService.Remove(employee.PathPhoto);

        _context.Employees!.Remove(employee);
        await _context.SaveChangesAsync();

        return JsonResponseBuilder<bool?>.NoContent();
    }

    private async void ValidateDataEmployeeAsync(dynamic employee, bool isNew)
    {
        var validationResult = isNew ? await _creationValidator.ValidateAsync(employee) : await _updateValidator.ValidateAsync(employee);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
    }

    private async Task<bool> IsDuplicateIdentificationAsync(string identification) =>
        await _context.Employees!.AnyAsync(e => e.Identification == identification);

    private async Task<string> SavePhotoAsync(string contentBase64, string identification, string extension)
    {
        using var stream = new MemoryStream(Convert.FromBase64String(contentBase64));
        return await _fileStorageService.SaveAsync(stream, $"{identification}.{extension}");
    }
}