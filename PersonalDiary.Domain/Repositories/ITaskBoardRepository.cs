using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Domain.Repositories
{
    public interface ITaskBoardRepository
    {
        Task Create(TaskBoard board);
        Task<TaskBoard> GetDetails(Guid id);
        Task<IReadOnlyList<TaskBoard>> GetList();
    }
}