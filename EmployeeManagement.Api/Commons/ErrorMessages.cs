namespace EmployeeManagement.Api.Commons;

public static class ErrorMessages
{
    public const string NotFound = "El recurso al que intentas acceder no existe.";
    public const string UrlAndBodyIdNotEqual = "El ID proporcionado en la URL y en el cuerpo de la petición no coinciden.";
    public const string IdentificationAlreadyExists = "Ya existe otro empleado con la misma identificacion.";
}