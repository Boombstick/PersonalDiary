using PersonalDiary.Application.Common;

namespace PersonalDiary.Application.Feature.City.Places
{
    public class BasePlacePagedListQuery<TType> : PagedListQueryBase where TType : struct, Enum
    {
        public long? CityId { get; set; }
        public TType? Type { get; set; }
        public string? SearchTerm { get; set; }
    }
}
