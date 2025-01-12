using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Domain.Repositories
{
    public interface ITaskBoardRepository : IRepository<TaskBoard>
    {
        Task<bool> BoardExists(Guid id);
        Task Create(TaskBoard board);
        Task<TaskBoard> GetDetails(Guid id);
        Task<IReadOnlyList<TaskBoard>> GetList();
    }
}