using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.MyTask;
using PersonalDiary.Domain.Models.FoodPlace;
using System.Text.RegularExpressions;

namespace PersonalDiary.Persistence
{
    public class DiaryDbContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<FoodPlace> FoodPlaces { get; set; }
        public DbSet<TaskBoard> TaskBoards { get; set; }

        public DiaryDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Преобразуем имя таблицы в snake_case
                entity.SetTableName(ToSnakeCase(entity.GetTableName()));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase((property.Name)));
                }
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(ToSnakeCase(key.GetName()));
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(ToSnakeCase(key.GetConstraintName()));
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(ToSnakeCase(index.GetDatabaseName()));
                }
            }
        }

        private string ToSnakeCase(string input)
        {
            // Преобразуем имя в нижний регистр с подчеркиваниями
            return Regex.Replace(
                Regex.Replace(input, @"([a-z])([A-Z])", "$1_$2"), // Разделяем строчные и заглавные буквы
                @"([A-Z])([A-Z][a-z])", "$1_$2")                // Разделяем заглавные и строчные после них
                .ToLower();
        }
    }
}
