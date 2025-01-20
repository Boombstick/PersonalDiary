namespace PersonalDiary.Domain.AbstractClasses
{
    public class RateableEntity
    {
        public long ReviewCount { get; set; }
        public float ReviewValue { get; set; }
        public float Assesment { get => (float)(ReviewValue / ReviewCount); }
    }
}
