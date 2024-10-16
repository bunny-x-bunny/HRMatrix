using Microsoft.AspNetCore.Http;

namespace HRMatrix.Application.Services.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadFileAsync(IFormFile? file, string folderName);
    Task DeleteFileAsync(string filePath);
}