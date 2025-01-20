namespace PersonalDiary.Domain.Models.Reviews
{
    public class Review
    {
        public long Id { get; set; }
        public virtual float Rating { get; set; }
        public string Description { get; set; }
    }
}
