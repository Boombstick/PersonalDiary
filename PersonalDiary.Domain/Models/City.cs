using PersonalDiary.Domain.Models.Places.WalkPlaces;
using PersonalDiary.Domain.Models.Places.FoodPlaces;
using PersonalDiary.Domain.Models.Places.CulturePlaces;

namespace PersonalDiary.Domain.Models
{
    public class City
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<WalkPlace> WalkPlaces { get; set; }
        public ICollection<FoodPlace> FoodPlaces { get; set; }
        public ICollection<CulturePlace> CulturePlaces { get; set; }
        public ICollection<Media> MediaFiles { get; set; }
        public City()
        {
            WalkPlaces = new List<WalkPlace>();
            FoodPlaces = new List<FoodPlace>();
            CulturePlaces = new List<CulturePlace>();
            MediaFiles = new List<Media>();
        }
    }
}
