using EmployeeManagement.Api.Models.Dtos;
using FluentValidation;

namespace EmployeeManagement.Api.Validators;

public class EmployeeCreationValidator : AbstractValidator<EmployeeCreationDto>
{
    public EmployeeCreationValidator()
    {
        RuleFor(e => e.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(e => e.LastName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(128);

        RuleFor(e => e.Identification)
            .NotNull()
            .NotEmpty()
            .MaximumLength(16);

        RuleFor(e => e.DateEntry)
            .NotNull();

        RuleFor(e => e.DateBirth)
            .NotNull();

        RuleFor(e => e.ContentBase64)
            .NotNull()
            .NotEmpty();

        RuleFor(e => e.Extension)
            .NotNull()
            .NotEmpty();
    }
}