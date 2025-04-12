namespace PersonalDiary.Domain.Models
{
    public class Media
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Path { get; set; }
        public DateTime UploadTime { get; set; }
        public MediaFileType Type { get; set; }
    }

    public enum MediaFileType
    {
        Photo,
        Video
    }
}
