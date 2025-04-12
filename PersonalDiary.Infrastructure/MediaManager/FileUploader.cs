using Microsoft.Extensions.Options;
using PersonalDiary.Application.Interfaces;
using PersonalDiary.Application.FileUploads;

namespace PersonalDiary.Infrastructure.MediaManager
{
    public class FileUploader : IFileUploader
    {
        private readonly FileStorageOptions _baseOptions;
        private static bool foldersIsCreated;
        public FileUploader(IOptions<FileStorageOptions> options)
        {
            var locker = new object();
            _baseOptions = options.Value;
            if (!foldersIsCreated)
            {
                lock (locker)
                {
                    var folderNames = options.Value.GetType().GetProperties().Where(x => x.Name != "BasePath").Select(x => x.GetValue(options.Value)!.ToString());
                    foreach (var folderName in folderNames)
                        Directory.CreateDirectory(Path.Combine(options.Value.BasePath, folderName!));

                    foldersIsCreated = true;
                }
            }
        }

        public async Task<string> UploadFileAsync(Stream fileStream, FileMediaType mediaType, string originalFileName, string CityName)
        {

            var targetFolder = Path.Combine(_baseOptions.BasePath, GetFileMediaPath(mediaType), CityName);
            Directory.CreateDirectory(targetFolder);
            var extension = Path.GetExtension(originalFileName);
            var fullPath = Path.Combine(targetFolder, $"{Guid.NewGuid()}{extension}");

            using (var stream = FileStreamWrite(fullPath))
            {
                await fileStream.CopyToAsync(stream);
            }

            return fullPath;
        }

        public async Task<bool> DeleteFileAsync(string path)
        {
            if (!File.Exists(path))
                return await Task.FromResult(false);

            try
            {
                File.Delete(path);
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }

        private string GetFileMediaPath(FileMediaType type)
        {
            switch (type)
            {
                case FileMediaType.Photo:
                    return _baseOptions.PhotosFolder;
                case FileMediaType.Video:
                    return _baseOptions.VideosFolder;
                default:
                    throw new ArgumentException($"Данный тип медиа файла не поддерживается {Enum.GetName(type)}");
            }
        }

        #region FileStream

        private static FileStream FileStreamWrite(string path)
        {
            return new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096,
                FileOptions.Asynchronous | FileOptions.SequentialScan);
        }

        #endregion
    }
}
