using Microsoft.AspNetCore.Http;

namespace HRMatrix.Application.Services.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadFileAsync(IFormFile? file, string folderName);
    Task DeleteFileAsync(string filePath);
    Task<string> CreateGifFromVideo(string videoFilePath, string outputFolder);
    Task<string> UploadGifAsync(string gifFilePath, string folderName);
}