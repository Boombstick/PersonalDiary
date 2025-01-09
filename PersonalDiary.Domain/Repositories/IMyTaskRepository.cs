using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Domain.Repositories
{
    public interface IMyTaskRepository
    {
        Task Create(MyTask task);
        Task<bool> ChangeTaskStatus(long id, Models.MyTask.TaskStatus newStatus);
        Task<MyTask> GetDetails(long id);
        Task<IReadOnlyList<MyTask>> GetPagedList(Guid? boardId, int page, int pageSize, DateTime? startDate, DateTime? endDate, DateTime? deadLineStart, DateTime? deadLineEnd, Models.MyTask.TaskStatus status);
    }
}