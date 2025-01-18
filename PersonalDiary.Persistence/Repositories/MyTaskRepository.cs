using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.MyTask;
using PersonalDiary.Persistence.Extensions;
using PersonalDiary.Persistence.Extensions.TaskExtensions;
using TaskStatus = PersonalDiary.Domain.Models.MyTask.TaskStatus;

namespace PersonalDiary.Persistence.Repositories
{
    public class MyTaskRepository : Repository<MyTask>, IMyTaskRepository
    {
        private readonly DiaryDbContext _diaryDbContext;
        public MyTaskRepository(DiaryDbContext diaryDbContext) : base(diaryDbContext)
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
            Guid? boardId,
            int page,
            int pageSize,
            DateTime? startDate,
            DateTime? endDate,
            DateTime? deadLineStart,
            DateTime? deadLineEnd,
            TaskStatus status)
        {
            var skip = (page - 1) * pageSize;
            return await _diaryDbContext.Tasks
                .Where(x => boardId == null || x.BoardId == boardId)
                .Where(x => status == 0 || x.Status == status)
                .CreatedBetweenDates(startDate, endDate)
                .DeadLineBetweenDates(deadLineStart, deadLineEnd)
                .OrderBy(t => t.Status == TaskStatus.WorkInProgress ? 1 :
                  t.Status == TaskStatus.Open ? 2 :
                  t.Status == TaskStatus.Completed ? 3 :
                  t.Status == TaskStatus.Canceled ? 4 : 5)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task ChangeStatus(long id, TaskStatus newStatus)
        {
            var task = await _diaryDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException();

            task.ChangeTaskStatus(newStatus);
            task.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            await _diaryDbContext.SaveChangesAsync();
        }
    }
}
