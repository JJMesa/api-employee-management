namespace EmployeeManagement.Api.Models.Dtos;

public class EmployeeUpdateDto
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateEntry { get; set; }

    public DateTime DateBirth { get; set; }

    public string ContentBase64 { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public bool ImageChange { get; set; }
}