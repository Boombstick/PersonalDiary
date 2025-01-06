using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Persistence.Repositories
{
    public class MyTaskRepository : IMyTaskRepository
    {
        private readonly DiaryDbContext _diaryDbContext;
        public MyTaskRepository(DiaryDbContext diaryDbContext)
        {
            _diaryDbContext = diaryDbContext;
        }
        public async Task Add(MyTask task)
        {
            _diaryDbContext.Tasks.Add(task);
            await _diaryDbContext.SaveChangesAsync();
        }
        public async Task<MyTask> GetDetails(long id)
        {
            return await _diaryDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id) ?? new MyTask();
        }
        public async Task<IReadOnlyList<MyTask>> GetPagedList(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await _diaryDbContext.Tasks.Skip(skip).Take(pageSize).ToListAsync();
        }
        public async Task<bool> ChangeTaskStatus(long id, Domain.Models.MyTask.TaskStatus newStatus)
        {
            var task = await _diaryDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
                return false;

            task.ChangeTaskStatus(newStatus);
            await _diaryDbContext.SaveChangesAsync();
            return true;
        }
    }
}
