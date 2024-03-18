namespace EmployeeManagement.Api.Models.Entities;

/// <summary>
/// Entidad que representa a un empleado
/// </summary>
public class Employee
{
    /// <summary>
    /// Identificador unico del empleado
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Numero de identificacion del documento del empleado
    /// </summary>
    public string Identification { get; set; } = null!;

    /// <summary>
    /// Nombre del empleado
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Apellido del empleado
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Fecha de ingreso a la compañia
    /// </summary>
    public DateTime DateEntry { get; set; }

    /// <summary>
    /// Fecha de nacimiento del empleado
    /// </summary>
    public DateTime DateBirth { get; set; }

    /// <summary>
    /// Ruta en la que se encuentra la foto del empleado
    /// </summary>
    public string PathPhoto { get; set; } = null!;
}