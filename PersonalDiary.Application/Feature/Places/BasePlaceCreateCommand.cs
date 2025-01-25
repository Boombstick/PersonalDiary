namespace PersonalDiary.Application.Feature.Places
{
    public class BasePlaceCreateCommand<TType> where TType : struct, Enum
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TType Type { get; set; }
        public long CityId { get; set; }
        public string Adress { get; set; }
    }
}
