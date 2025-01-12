using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.MyTask;

namespace PersonalDiary.Persistence.Repositories
{
    public class TaskBoardRepository : Repository<TaskBoard>, ITaskBoardRepository
    {
        private readonly DiaryDbContext _diaryDbContext;
        public TaskBoardRepository(DiaryDbContext diaryDbContext) : base(diaryDbContext)
        {
            _diaryDbContext = diaryDbContext;
        }
        public async Task Create(TaskBoard board)
        {
            _diaryDbContext.TaskBoards.Add(board);
            await _diaryDbContext.SaveChangesAsync();
        }
        public async Task<TaskBoard> GetDetails(Guid id)
        {
            return await _diaryDbContext.TaskBoards
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == id) ?? new TaskBoard();
        }
        public async Task<IReadOnlyList<TaskBoard>> GetList()
        {
            return await _diaryDbContext.TaskBoards.ToListAsync();
        }
        public async Task<bool> BoardExists(Guid id)
        {
            return await _diaryDbContext.TaskBoards.AnyAsync(x => x.Id == id);
        }
    }
}
