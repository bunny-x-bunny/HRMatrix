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

    public async Task<string> CreateGifFromVideo(string videoFilePath, string outputFolder)
    {
        var gifFileName = $"{Guid.NewGuid()}.gif";
        var gifFilePath = Path.Combine(outputFolder, gifFileName);
        
        var ffmpegArgs = $"-t 4 -i \"{videoFilePath}\" -vf \"fps=10,scale=320:-1\" -gifflags +transdiff \"{gifFilePath}\"";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = ffmpegArgs,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        await process.WaitForExitAsync();
        
        if (File.Exists(gifFilePath))
        {
            return gifFilePath;
        }

        throw new Exception("Ошибка при создании GIF из видео.");
    }

    public async Task<string> UploadGifAsync(string gifFilePath, string folderName)
    {
        var destinationPath = Path.Combine(_storagePath, folderName, Path.GetFileName(gifFilePath));
        File.Copy(gifFilePath, destinationPath);
        return $"{_baseUrl}/{folderName}/{Path.GetFileName(gifFilePath)}";
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