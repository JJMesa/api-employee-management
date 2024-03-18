using EmployeeManagement.Api.Models.Dtos;
using FluentValidation;

namespace EmployeeManagement.Api.Validators;

public class EmployeeUpdateValidator : AbstractValidator<EmployeeUpdateDto>
{
    public EmployeeUpdateValidator()
    {
        RuleFor(e => e.EmployeeId)
            .NotNull()
            .NotEmpty();

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
            .NotEmpty()
            .When(e => e.ImageChange);

        RuleFor(e => e.Extension)
            .NotNull()
            .NotEmpty()
            .When(e => e.ImageChange);
    }
}