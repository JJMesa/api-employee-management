using EmployeeManagement.Api.Commons;
using EmployeeManagement.Api.interfaces;

namespace EmployeeManagement.Api.Services;

internal class FileStorageService : IFileStorageService
{
    private readonly IWebHostEnvironment _env;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FileStorageService(IWebHostEnvironment env
        , IHttpContextAccessor httpContextAccessor)
    {
        _env = env;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> SaveAsync(MemoryStream stream, string fileName)
    {
        string folder = Path.Combine(_env.WebRootPath, Routes.EMPLOYEE_RESOURCE);

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string filePath = Path.Combine(folder, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        await File.WriteAllBytesAsync(filePath, stream.ToArray());

        var baseUrl = $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}";
        var urlPath = Path.Combine(baseUrl, Routes.EMPLOYEE_RESOURCE, fileName).Replace("\\", "/");
        return urlPath;
    }

    public void Remove(string webPath)
    {
        string baseUrl = $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}";
        string urlPath = Path.Combine(baseUrl, Routes.EMPLOYEE_RESOURCE).Replace("\\", "/");
        string fileName = webPath.Replace(urlPath, "").Replace("/", "");
        string folder = Path.Combine(_env.WebRootPath, Routes.EMPLOYEE_RESOURCE);
        string filePath = Path.Combine(folder, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}