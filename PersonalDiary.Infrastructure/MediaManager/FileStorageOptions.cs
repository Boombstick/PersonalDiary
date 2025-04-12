namespace PersonalDiary.Infrastructure.MediaManager
{
    public class FileStorageOptions
    {
        /// <summary>
        /// Путь к базовой папке с статическими файлами
        /// </summary>
        public required string BasePath { get; set; }
        /// <summary>
        /// Название подпапки для фотографий
        /// </summary>
        public required string PhotosFolder { get; set; }
        /// <summary>
        /// Название подпапки для видео
        /// </summary>
        public required string VideosFolder { get; set; }
    }
}
