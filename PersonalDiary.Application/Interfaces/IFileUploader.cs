using PersonalDiary.Application.FileUploads;

namespace PersonalDiary.Application.Interfaces
{
    public interface IFileUploader
    {
        Task<bool> DeleteFileAsync(string path);
        Task<string> UploadFileAsync(Stream fileStream, FileMediaType mediaType, string originalFileName, string CityName);
    }
}