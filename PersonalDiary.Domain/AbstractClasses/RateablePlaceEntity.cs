namespace PersonalDiary.Domain.AbstractClasses
{
    public abstract class RateablePlaceEntity<TEntity, TReviewCollection, TType> : Place<TType>
        where TReviewCollection : Review<TEntity>
        where TType : Enum
    {
        public float AverageRating { get; set; }
        public long ReviewCount { get; set; }
        public virtual ICollection<TReviewCollection> Reviews { get; set; }
    }
}
