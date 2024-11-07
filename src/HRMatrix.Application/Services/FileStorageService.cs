using System.Diagnostics;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Application.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HRMatrix.Application.Services;

public class FileStorageService : IFileStorageService
{
    private readonly string _storagePath;
    private readonly string _baseUrl;

    public FileStorageService(IOptions<AppSettings> appSettings)
    {
        _storagePath = appSettings.Value.StoragePath;
        _baseUrl = appSettings.Value.BaseUrl; 

        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    public async Task<string> UploadFileAsync(IFormFile? file, string folderName)
    {
        Console.WriteLine($"UploadFileAsync called with folderName: {folderName}");

        var folderPath = Path.Combine(_storagePath, folderName);
        Console.WriteLine($"Full folder path: {folderPath}");

        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Directory does not exist. Creating: {folderPath}");
            Directory.CreateDirectory(folderPath);
        }

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(folderPath, fileName);
        Console.WriteLine($"Full file path: {filePath}");

        if (file != null)
        {
            Console.WriteLine("File is not null. Starting file copy...");
            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            Console.WriteLine("File copied successfully.");
        }
        else
        {
            Console.WriteLine("File is null. Skipping file copy.");
        }

        var fileUrl = $"{_baseUrl}/{folderName}/{fileName}";
        Console.WriteLine($"Returning file URL: {fileUrl}");

        return fileUrl;
    }



    public Task DeleteFileAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        return Task.CompletedTask;
    }
}