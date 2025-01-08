using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.MyTask;
using PersonalDiary.Persistence.Extensions;
using PersonalDiary.Persistence.Extensions.TaskExtensions;

namespace PersonalDiary.Persistence.Repositories
{
    public class MyTaskRepository : IMyTaskRepository
    {
        private readonly DiaryDbContext _diaryDbContext;
        public MyTaskRepository(DiaryDbContext diaryDbContext)
        {
            _diaryDbContext = diaryDbContext;
        }
        public async Task Create(MyTask task)
        {
            _diaryDbContext.Tasks.Add(task);
            await _diaryDbContext.SaveChangesAsync();
        }
        public async Task<MyTask> GetDetails(long id)
        {
            return await _diaryDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id) ?? new MyTask();
        }
        public async Task<IReadOnlyList<MyTask>> GetPagedList(
            Guid boardId,
            int page,
            int pageSize,
            DateTime? startDate,
            DateTime? endDate,
            DateTime? deadLineStart,
            DateTime? deadLineEnd,
            Domain.Models.MyTask.TaskStatus status)
        {
            var skip = (page - 1) * pageSize;
            return await _diaryDbContext.Tasks
                .Where(x => x.BoardId == boardId)
                .Where(x => status == Domain.Models.MyTask.TaskStatus.All || x.Status == status)
                .CreatedBetweenDates(startDate, endDate)
                .DeadLineBetweenDates(deadLineStart, deadLineEnd)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<bool> ChangeTaskStatus(long id, Domain.Models.MyTask.TaskStatus newStatus)
        {
            var task = await _diaryDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
                return false;

            task.ChangeTaskStatus(newStatus);
            task.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            await _diaryDbContext.SaveChangesAsync();
            return true;
        }
    }
}
