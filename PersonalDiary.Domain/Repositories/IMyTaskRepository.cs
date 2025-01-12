using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Domain.Repositories
{
    public interface IMyTaskRepository : IRepository<MyTask>
    {
        Task ChangeStatus(long id, Models.MyTask.TaskStatus newStatus);
        Task Create(MyTask task);
        Task<MyTask> GetDetails(long id);
        Task<IReadOnlyList<MyTask>> GetPagedList(Guid? boardId, int page, int pageSize, DateTime? startDate, DateTime? endDate, DateTime? deadLineStart, DateTime? deadLineEnd, Models.MyTask.TaskStatus status);
    }
}