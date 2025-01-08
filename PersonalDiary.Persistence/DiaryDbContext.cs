using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.MyTask;
using PersonalDiary.Domain.Models.FoodPlace;

namespace PersonalDiary.Persistence
{
    public class DiaryDbContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<FoodPlace> FoodPlaces { get; set; }

        public DiaryDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
