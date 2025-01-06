using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Domain.Repositories
{
    public interface IMyTaskRepository
    {
        Task Add(MyTask task);
        Task<bool> ChangeTaskStatus(long id, Models.MyTask.TaskStatus newStatus);
        Task<MyTask> GetDetails(long id);
        Task<IReadOnlyList<MyTask>> GetPagedList(int page, int pageSize);
    }
}