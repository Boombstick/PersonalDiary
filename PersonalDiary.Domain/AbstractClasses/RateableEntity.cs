using PersonalDiary.Domain.Models.Reviews;

namespace PersonalDiary.Domain.AbstractClasses
{
    public class RateableEntity<TReviewCollection,TType> : Place<TType>
        where TReviewCollection : Review
        where TType : Enum
    {
        public float AverageRating { get; set; }
        public long ReviewCount { get; set; }
        public virtual ICollection<TReviewCollection> Reviews { get; set; }
    }
}
