using PersonalDiary.Domain.Repositories;

namespace PersonalDiary.Persistence.Repositories.DictionaryRepository
{
    public partial class DictionaryRepository : IDictionaryRepository
    {
        private readonly DiaryDbContext _diaryDbContext;
        public DictionaryRepository(DiaryDbContext diaryDbContext)
        {
            _diaryDbContext = diaryDbContext;
        }
    }
}
