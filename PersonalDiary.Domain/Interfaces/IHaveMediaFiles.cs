using PersonalDiary.Domain.Models;

namespace PersonalDiary.Domain.Interfaces
{
    public interface IHaveMediaFiles
    {
        public ICollection<Media> MediaFiles { get; set; }
    }
}
