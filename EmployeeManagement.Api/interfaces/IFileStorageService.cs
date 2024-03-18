namespace EmployeeManagement.Api.interfaces;

public interface IFileStorageService
{
    Task<string> SaveAsync(MemoryStream stream, string fileName);

    void Remove(string webPath);
}